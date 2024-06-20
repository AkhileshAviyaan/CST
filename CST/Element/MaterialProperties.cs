using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST.Element
{
    public class MaterialProperties
    {
        public double E { get; set; }
        public double t { get; set; }
        public double Gamma { get; set; }
        public double Rho { get; set; }
        public MaterialProperties() { }
        /// <summary>
        /// Constructor to Assign E,t,Gamma, Rho
        /// </summary>
        /// <param name="e"></param>
        /// <param name="t"></param>
        /// <param name="gamma"></param>
        /// <param name="rho"></param>
        public MaterialProperties(double e, double t, double gamma, double rho)
        {
            E = e;
            this.t = t;
            Gamma = gamma;
            Rho = rho;
        }
        public double Area { get; set; }
    }
}
