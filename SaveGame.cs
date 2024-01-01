using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace O_Neillo
{
    public class SaveGame
    {
        public string p1Name;
        public string p2Name;
        public int p1TokenNum;
        public int p2TokenNum;
        public int nextPlayerNum; // will be worked out from current state of label
        public bool speechTicked;
        public bool infoPanelTicked;
        public int[,] boardState;
        public string selectedFile;
        //need some way of obtaining name of the file option user chooses (gameFile1ToolStripMenuItem.Text will be first part of the .WriteAllText line)
        public SaveGame(string p1Name, string p2Name, int p1TokenNum, int p2TokenNum, int nextPlayerNum, bool speechTicked, bool infoPanelTicked,int[,] boardState, string selectedFile)
        {
            this.p1Name = p1Name;
            this.p2Name = p2Name;
            this.p1TokenNum = p1TokenNum;
            this.p2TokenNum = p2TokenNum;
            this.nextPlayerNum = nextPlayerNum;
            this.speechTicked= speechTicked;
            this.infoPanelTicked= infoPanelTicked;
            this.boardState = boardState;
            this.selectedFile = selectedFile;
        }
        public void writeData(SaveGame gameData)
        {
            string stringComposite = JsonConvert.SerializeObject(gameData, Formatting.Indented); //passing in object to serialize, .indented = formats Json string to be in brackets
            File.WriteAllText(gameData.selectedFile, stringComposite);
        }
    }
}
