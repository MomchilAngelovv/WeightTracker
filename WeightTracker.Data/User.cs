using System;
using System.Collections.Generic;
using System.Text;

namespace WeightTracker.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretWord { get; set; }

        public virtual ICollection<Weight> Weights { get; set; } = new List<Weight>();
    }
}
