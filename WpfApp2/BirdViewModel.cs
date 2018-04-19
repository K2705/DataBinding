using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class BirdViewModel
    {
        public static List<Bird> Get3TestBirds()
        {
            List<Bird> birds = new List<Bird>();
            birds.Add(new Bird() { Name = "Angry", ImgFile = "BirdRed.PNG", Value = 1000 });
            birds.Add(new Bird() { Name = "Nasty", ImgFile = "BirdBlack.PNG", Value = 1500 });
            birds.Add(new Bird() { Name = "Curious", ImgFile = "BirdYellow.PNG", Value = 2000 });
            return birds;
        }
    }
}
