using System;
using System.Collections.Generic;
using System.Text;

namespace HangManGame
{

    public class Settings
    {
        public string[] Words { get; set; } = new string[]{
            "python",
            "dotnet",
            "java",
            "nodejs"
        };
        public bool IsRepeatedAttemptWrong { get; set; } = true;
        public int MaxTries = 2;
        public char SecretChar = '@';
    }
}
