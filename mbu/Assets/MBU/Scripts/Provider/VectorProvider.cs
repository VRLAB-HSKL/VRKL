using UnityEngine;

namespace VRKL.MBU
{
    /// <summary>
    /// Klasse, die einen Vektor mit drei  float-Komponenten verwaltet.
    /// Es gibt Funktionen für die Veränderung der Koordinaten, und es wird
    /// für jede Komponenten ein zulässiges Intervall definiert,
    /// das mit Hilfe von Clamp eingehalten wird.
    ///
    /// Man könnte ein Subject daraus machen, darauf wurde erstmal verzichtet.
    /// </summary>
    public class VectorProvider
    {
     /// <summary>
        /// Set und Get für den skalaren Wert
        /// </summary>
        public Vector3 value
        {
            get => _value;
            set => _value = this.value;
        }
        
        /// <summary>
        /// Set und Get für das Delta zum
        /// Verändern des Werts
        /// </summary>
        public Vector3 delta
        {
            get => _delta;
            set => _delta = this.delta;
        }

        /// <summary>
        /// Set und Get für das Minimum des Werts
        /// </summary>
        public Vector3 minimum
        {
            get => _min;
            set => _min = this.minimum;
        }
        
        /// <summary>
        /// Set und Get für das Maximum des Werts
        /// </summary>
        public Vector3 maximum
        {
            get => _max;
            set => _max = this.maximum;
        }
        
        /// <summary>
        /// Den Wert um ein Delta erhöhen
        /// </summary>
        public void Increase()
        {
            Vector3 sum = _value + delta;
            _value.x = Mathf.Clamp(sum.x, _min.x, _max.x);
            _value.y = Mathf.Clamp(sum.y, _min.y, _max.y);
            _value.z = Mathf.Clamp(sum.z, _min.z, _max.z);
        }
        
        /// <summary>
        /// Den Wert um ein Delta erniedrigen
        /// </summary>
        public void Decrease()
        {
            Vector3 diff = _value - delta;
            _value.x = Mathf.Clamp(diff.x, _min.x, _max.x);
            _value.y = Mathf.Clamp(diff.y, _min.y, _max.y);
            _value.z = Mathf.Clamp(diff.z, _min.z, _max.z);
        }

        /// <summary>
       /// Wert und Delta setzen.
       /// <remarks>
       /// Minimum und Maximum wird auf -infty und infty gesetzt.
       /// </remarks>
       /// <param name="theValue">Anfangswerte</param>
       /// <param name="theDelta">Werte für die Veränderung </param>
       /// </summary>
       public VectorProvider(Vector3 theValue, Vector3 theDelta)
       {
           _value = theValue;
           _delta = theDelta;
           _min = Vector3.negativeInfinity;;
           _max = Vector3.positiveInfinity;
       }
  
        /// <summary>
        /// Wert,  Delta, Minimum und Maximum setzen.
        /// <param name="theValue">Anfangsweret</param>
        /// <param name="theDelta">Weret für die Veränderung </param>
        /// <param name="theMin">Minimalr Werte</param>
        /// <param name="theDelta">Maximale Werte </param>
        /// </summary>
        public VectorProvider(Vector3 theValue, Vector3 theDelta,
                                      Vector3 theMin, Vector3 theMax)
        {
            _value = theValue;
            _delta = theDelta;
            _min = theMin;
            _max = theMax;
        }

        /// <summary>
       /// Der Vektort, den diese Klasse liefert.
       /// </summary>
       private Vector3 _value;
       
       /// <summary>
       /// DerVektorr, den wir für die Veränderung
       /// des skalaren Werts einsetzen.
       /// </summary>
       private Vector3 _delta;

       /// <summary>
       /// Minimale Werte, die angenommen werden können.
       /// In Increase und Decrease wird ein Clamp durchgeführt.
       /// Damit ist garantiert, dass der Wert immer im zulässigen
       /// Intervall liegt.
       /// </summary>
       private Vector3 _min;
  
       /// <summary>
       /// Maximalr Werte, die angenommen werden können.
       /// In Increase und Decrease wird ein Clamp durchgeführt.
       /// Damit ist garantiert, dass der Wert immer im zulässigen
       /// Intervall liegt.
       /// </summary>
       private Vector3 _max;       

    }
}
