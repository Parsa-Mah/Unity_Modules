
namespace PM.Dialogue_System.Models
{
    class DialogueModel
    {
        string dialogueText;
        int timeToShow;

        public DialogueModel(string dialogueText, int timeToShow)
        {
            this.dialogueText = dialogueText;
            this.timeToShow = timeToShow;
        }
    }
}
