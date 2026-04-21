using _ProjectFiles.DialogueSystem.Scripts.Data;
using _ProjectFiles.NPC.Scripts.Data;

namespace _ProjectFiles.NPC.Scripts.Logic
{
    public interface INpcDialogueResolver
    {
        DialogueConfig Resolve(NpcModel npcModel);
    }
}