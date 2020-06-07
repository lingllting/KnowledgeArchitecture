using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCTest : MonoBehaviour
{
    private void Start()
    {
        GCNotification.GCDone += delegate(int i)
        {
            Debug.Log(string.Format("gc {0} generation", i));
        };
        for (int i = 0; i < 1000; i++)
        {
            new object();
        }
    }
}

public class GCNotification
{
    private static Action<int> s_gcDone = null;

    public static event Action<int> GCDone
    {
        add
        {
            if (s_gcDone == null)
            {
                new GenObject(0);
                new GenObject(2);
                s_gcDone += value;
            }
        }
        remove { s_gcDone -= value; }
    }
    
    private sealed class GenObject
    {
        private int _generation;

        public GenObject(int generation)
        {
            _generation = generation;
        }

        ~GenObject()
        {
            if (GC.GetGeneration(this) >= _generation)
            {
                if (s_gcDone != null)
                {
                    s_gcDone(_generation);
                }
            }

            if (s_gcDone != null && !AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
            {
                if (_generation == 0)
                {
                    new GenObject(0);
                }
                else
                {
                    GC.ReRegisterForFinalize(this);
                }
            }
            else
            {
                
            }
        }
    }
}

