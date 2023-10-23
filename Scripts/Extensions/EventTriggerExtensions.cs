using UnityEngine.EventSystems;
using UnityEngine.Events;

public static class EventTriggerExtensions {
    public static void AddEntry(
        this EventTrigger trigger,
        EventTriggerType triggerType, 
        UnityAction<BaseEventData> callback
    ) {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = triggerType;
        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);
    }

    public static void AddPointerClickEntry(this EventTrigger trigger, UnityAction<PointerEventData> callback) {
        trigger.AddEntry(EventTriggerType.PointerClick, (data) => {
            callback((PointerEventData)data);
        });
    }
}
