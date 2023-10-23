using System;

public static class FloatExtensions {
    public static int ToInt(this float value) {
        return (int)value;
    }
}

public static class DoubleExtensions {
    public static int ToInt(this double value) {
        return (int)value;
    }
}

public static class IntExtensions {
    public static bool ToBool(this int value) {
        return value == 0 ? false : true;
    }

    public static void Times(this int count, Action action) {
        for (int i = 0; i < count; i++) {
            action?.Invoke();
        }
    }
}

public static class BoolExtensions {
    public static int ToInt(this bool flag) {
        return flag ? 1 : 0;
    }

    public static bool Toggle(this bool flag) {
        return !flag;
    }
}