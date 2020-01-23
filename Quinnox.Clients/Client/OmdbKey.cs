using Quinnox.OmdbApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quinnox.OmdbApi.Client
{
    public class OmdbKey : IOmdbKey
    {
        //  string Key= "b473dec9"
        private readonly  string _key;
        public OmdbKey(string key)
        {
            _key = key;
        }
        public string Key { get => _key; set => throw new NotImplementedException(); }
    }
}
