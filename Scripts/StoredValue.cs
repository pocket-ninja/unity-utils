using System;
using UnityEngine;
using Newtonsoft.Json;

[Serializable]
public class StoredValue<T> {
    public T defaultValue;
    public string key;
    public bool saveOnChange;
    public event Action<T> valueChanged;

    public T value {
        get {
            MaybeRestore();
            return _value;
        }
        set {
            _value = value;
            ValueChanged();
        }
    }

    private T _value;
    private bool _restored;
    private Action<string, T> saveAction;
    private Func<string, T, T> restoreAction;

    public void Save() {
        saveAction(key, _value);
    }

    private void ValueChanged() {
        valueChanged?.Invoke(_value);

        if (saveOnChange) {
            Save();
        }
    }

    private void Restore() {
        _value = restoreAction(key, defaultValue);
    }

    private void MaybeRestore() {
        if (!_restored) {
            Restore();
            _restored = true;
        }
    }

    public StoredValue(string key, T defaultValue, bool saveOnChange, Action<string, T> saveAction, Func<string, T, T> restoreAction) {
        this.key = key;
        this.defaultValue = defaultValue;
        this.saveOnChange = saveOnChange;
        this.saveAction = saveAction;
        this.restoreAction = restoreAction;
    }
}

public static class StoredValue {
    public static StoredValue<int> PlayerPrefsInt(string key, int defaultValue = 0, bool saveOnChange = true) {
        return new StoredValue<int>(
            key,
            defaultValue,
            true,
            (k, v) => PlayerPrefs.SetInt(k, v),
            (k, dv) => PlayerPrefs.GetInt(k, dv)
        );
    }

    public static StoredValue<string> PlayerPrefsString(string key, string defaultValue = null, bool saveOnChange = true) {
        return new StoredValue<string>(
            key,
            defaultValue,
            true,
            (k, v) => PlayerPrefs.SetString(k, v),
            (k, dv) => PlayerPrefs.GetString(k, dv)
        );
    }

    public static StoredValue<float> PlayerPrefsFloat(string key, float defaultValue = 0, bool saveOnChange = true) {
        return new StoredValue<float>(
            key,
            defaultValue,
            true,
            (k, v) => PlayerPrefs.SetFloat(k, v),
            (k, dv) => PlayerPrefs.GetFloat(k, dv)
        );
    }

    public static StoredValue<bool> PlayerPrefsBool(string key, bool defaultValue = false, bool saveOnChange = true) {
        return new StoredValue<bool>(
            key,
            defaultValue,
            true,
            (k, v) => PlayerPrefs.SetInt(k, v.ToInt()),
            (k, dv) => PlayerPrefs.GetInt(k, dv.ToInt()).ToBool()
        );
    }

    public static StoredValue<DateTime> PlayerPrefsDateTime(string key, DateTime defaultValue, bool saveOnChange = true) {
        return new StoredValue<DateTime>(
            key,
            defaultValue,
            true,
            (k, v) => PlayerPrefs.SetString(k, v.ToString()),
            (k, dv) => DateTime.Parse(PlayerPrefs.GetString(k, dv.ToString()))
        );
    }

    public static StoredValue<T> PlayerPrefsJson<T>(string key, T defaultValue, bool saveOnChange = true) {
        return new StoredValue<T>(
            key,
            defaultValue,
            true,
            (k, v) => {
                var json = JsonConvert.SerializeObject(v);
                PlayerPrefs.SetString(k, json);
            },
            (k, dv) => {
                var json = PlayerPrefs.GetString(k);
                if (json == null || json == "") {
                    return dv;
                }

                var restored = JsonConvert.DeserializeObject<T>(json);
                return restored ?? dv;
            }
        );
    }
    
    public static StoredValue<SerializableVector3> PlayerPrefsVector3(string key, SerializableVector3 defaultValue, bool saveOnChange = true) { 
        return PlayerPrefsJson(key, defaultValue, saveOnChange);
    }
}
