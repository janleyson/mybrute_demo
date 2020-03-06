using UnityEngine;
using System.Collections;

namespace Framework.MVC
{

    /// <summary>
    /// Base class for all Model related classes.
    /// </summary>
    public class Model : Element
    {

    }


    /// <summary>
    /// Base class for all Model related classes.
    /// </summary>
    public class Model<T> : Model where T : BaseApplication
    {
        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        new public T App { get { return (T)base.App; } }
    }
}