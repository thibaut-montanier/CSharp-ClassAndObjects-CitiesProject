using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Services.ETL {
public abstract class ETLMain<TInput, TOutput> where TInput :class
                                where TOutput : IDBObject, new() {

    /// <summary>
    /// Load data : must be override in another class
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<TInput> LoadAll();

    /// <summary>
    /// TransoformeOne : transfer datas from input to outpu
    /// </summary>
    /// <param name="ti"></param>
    /// <param name="to"></param>
    protected abstract void TransformeOne(TInput ti, TOutput to);

    /// <summary>
    /// Transforme all data from source (load) to any destination
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TOutput> TransformeAll() {
        int counter = 0;
        foreach(var ti in LoadAll()) {
            var to = new TOutput();
            // counter management for the ID
            to.ID = ++counter;
            TransformeOne(ti, to);
            yield return to;
        }
    }
}
}
