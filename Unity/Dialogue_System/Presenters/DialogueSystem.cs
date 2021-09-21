using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Dialogue_System.Models;

namespace PM.Util.Dialogue_System
{
    class DialogueSystem
    {
        public ConversationModel conversationModel;

        public DialogueSystem()
        {
            this.conversationModel = new ConversationModel();
        }

        public void AddNPC(string name, int age = 18)
        {
            int _id = conversationModel.npcList.Count();
            NPCModel npcModel = new NPCModel(_id, name, age);
            conversationModel.npcList.Add(npcModel);
        }

        public void AddDialogue(string dialogueText, int timeToShow)
        {
            DialogueModel dialogueModel = new DialogueModel(dialogueText, timeToShow);
            conversationModel.dialogueList.Add(dialogueModel);
        }
    }
}
