using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace O_Neillo
{
    /// <summary>
    /// Class <c>SaveGame</c> used to specify the attributes and methods of SaveGame objects
    /// A SaveGame object stores the data related to a game state, either for saving a game state or restoring a previously saved one
    /// </summary>
    public class SaveGame
    {
        //attributes which the SaveGame object consists of (i.e. all data which needs to be stored or restored about a game state)
        public string p1Name;
        public string p2Name;
        public int p1TokenNum;
        public int p2TokenNum;
        public int nextPlayerNum;
        public bool speechTicked;
        public bool infoPanelTicked;
        public int[,] boardState;
        public string selectedFile;
        /// <summary>
        /// Method <c>SaveGame</c> constructor for SaveGame class
        /// </summary>
        /// <param name="p1Name"></param>
        /// <param name="p2Name"></param>
        /// <param name="p1TokenNum"></param>
        /// <param name="p2TokenNum"></param>
        /// <param name="nextPlayerNum"></param>
        /// <param name="speechTicked"></param>
        /// <param name="infoPanelTicked"></param>
        /// <param name="boardState"></param>
        /// <param name="selectedFile"></param>
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
        /// <summary>
        /// Method <c>writeData</c> receives SaveGame object and serializes it to store the game state
        /// Used in FrmGame.cs
        /// </summary>
        /// <param name="gameData"></param>
        public void writeData(SaveGame gameData)
        {
            string stringComposite = JsonConvert.SerializeObject(gameData, Formatting.Indented); //pass in SaveGame object to serialize
            File.WriteAllText(gameData.selectedFile, stringComposite);
        }
    }
}
