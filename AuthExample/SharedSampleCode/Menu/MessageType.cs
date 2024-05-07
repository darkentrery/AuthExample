namespace AuthExample.SharedSampleCode.Menu
{
    // When calling SampleMenu.WriteMessage, pass in one of these enum values as
    // the messageType.
    public enum MessageType
    {
        // Use this value to write out
        //
        //   ---Message here---
        //
        Special = 0,

        // Use this value to write out
        //   Message here
        Title = 1,

        // Use this value to write out
        //   8 - Message here
        MenuLine = 2,
    }
}