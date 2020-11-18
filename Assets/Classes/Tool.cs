using System;
using Classes.Enums;

namespace Classes
{
    [Serializable]
    public class Tool
    {
        public string name;
        public ToolType type;

        public Tool(string name = "none", ToolType type = ToolType.None)
        {
            this.name = name;
            this.type = type;
        }
    }
}