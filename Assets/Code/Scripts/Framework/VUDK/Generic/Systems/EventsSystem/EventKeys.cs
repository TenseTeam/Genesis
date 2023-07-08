namespace VUDK.Generic.Systems.EventsSystem.Events
{
    public static class EventKeys
    {
        public static class CountdownEvents
        {
            public const string OnCountdownTimesUp = "OnCountdownTimesUp";
            public const string OnCountdownCount = "OnCountDownCount";
        }

        public static class InteractEvents
        {
            public const string OnPickup = "OnPickup";
        }

        public static class ScoreEvents
        {
            public const string OnScoreChange = "OnScoreChange";
            public const string OnHighScoreChange = "OnHighScoreChange";
        }

        public static class DialogueEvents
        {
            public const string OnDialougeTypedLetter = "OnDialougeTypedLetter";
            public const string OnTriggerDialouge = "OnTriggerDialogue";
        }
    }
}