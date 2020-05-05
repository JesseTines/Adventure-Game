using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Explorable_Areas
{
    class ExtraImportantItem : AdventureGameItem
    {
        public string outcome;
        public string focus;
        public string material;
        public ExtraImportantItem(string name, string modifier, string Outcome, string Focus, string Material)
            : base(name, modifier)
        {
            outcome = Outcome;
            focus = Focus;
            material = Material;
        }

        // This method draws items.
        public override void Present(int ItemNumber)
        {
            switch (ItemNumber)
            {
                case 1:
                    // source: https://ascii.co.uk/art/compass
                    WriteLine(@"
|<><><><><><><><><><><><><><><><><><><><><><><>|
|                      *                       |
|   /\~~~~~~~~~~~~~~~~~|~~~~~~~~~~~~~~~~~/\    |
|  (o )                .                ( o)   |
|   \/               .` `.               \/    |
|   /\             .`     `.             /\    |
|  (             .`         `.             )   |
|   )          .`      N      `.          (    |
|  (         .`   A    |        `.         )   |
|   )      .`     <\> )|(         `.      (    |
|  (     .`         \  |  (         `.     )   |
|   )  .`         )  \ |    (         `.  (    |
|    .`         )     \|      (         `.     |
|  .`     W---)--------O--------(---E     `.   |
|   `.          )      |\     (          .`    |
|   ) `.          )    | \  (          .` (    |
|  (    `.          )  |  \          .`    )   |
|   )     `.          )|( <\>      .`     (    |
|  (        `.         |         .`        )   |
|   )         `.       S       .`         (    |
|  (            `.           .`            )   |
|   \/            `.       .`            \/    |
|   /\              `.   .`              /\    |
|  (o )               `.`               ( o)   |
|   \/~~~~~~~~~~~~~~~~~|~~~~~~~~~~~~~~~~~\/    |
|                     -|-                   LGB|
|<><><><><><><><><><><><><><><><><><><><><><><>|");
                    break;
                case 2:
                    // source: https://www.asciiart.eu/weapons/shields
                    WriteLine(@"
\_              _/
] --__________-- [
|       ||       |
\       ||       /
 [      ||      ]
 |______||______|
 |------..------|
 ]      ||      [
  \     ||     /
   [    ||    ]
   \    ||    /
    [   ||   ]
     \__||__/
        --");
                    break;
                case 3:
                    // source: https://ascii.co.uk/art/helmet
                    WriteLine(@"
                   _
                ,''/., _
        `.-._\`/. ( //'/'`.
      _.-`-. ``' ` `(   -. \
    ,'  ,    ,-:._ _..-.. \/
   / ,'/ ,`.( _.'-'.     )/
   `.\ '(   ,'      `.
      `._\ /'       \ \
          /:         \ \-.
        ,;':._______...-'_)
        \:/-.._______..-_|
         : :\   `----'|'-;
          \ :\    : : ;:/
           \ ``.   ; /;/
            )   `.  /,'
          ,'      `-' \
         /  .--.       )
        /_.---._`._   /
                `.__.'");
                    break;
            }
        }
        
        

        
    }
}
