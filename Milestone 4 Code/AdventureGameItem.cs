using System;
using System.Collections.Generic;
using System.Text;

namespace Explorable_Areas
{
    class AdventureGameItem
    {
        public string name;
        public string modifier;

        public AdventureGameItem(string Name, string Modifier)
        {
            name = Name;
            modifier = Modifier;
        }

        // See: ExtraImportantItem class
        public virtual void Present(int itemnumber)
        {

        }


    }

   
    

    
}
