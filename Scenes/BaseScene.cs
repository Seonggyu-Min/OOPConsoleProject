﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Scenes
{
    public abstract class BaseScene
    {
        public string name;

        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Result();
    }
}
