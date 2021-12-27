using System;
using System.Collections.Generic;
using System.Text;

namespace Hectre.Storage.MongoDB
{
    public class ChemicalsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null;

        public string DatabaseName { get; set; } = null;

        public string ChemicalsCollectionName { get; set; } = null;
    }
}
