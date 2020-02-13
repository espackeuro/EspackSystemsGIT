using System;
using System.Collections.Generic;
using System.Linq;


namespace IData
{
    public class ExtendedTable : List<IExtendedRecord>
    {
        public string DataBase { get; set; }
        public string ProcedureName { get; set; }
        public bool HasItemsToTransfer
        {
            get => (UnTransferredItems.Count > 0);
        }
        public List<IExtendedRecord> UnTransferredItems
        {
            get => this.Where(r => r.Status == dataStatus.DATABASE).ToList();
        }
        public IExtendedRecord ItemToTransfer
        {
            get => UnTransferredItems.OrderBy(o => o.IdReg).FirstOrDefault();
        }

        public ExtendedTable(string dataBase, string procedureName)
        {
            DataBase = dataBase ?? throw new ArgumentNullException(nameof(dataBase));
            ProcedureName = procedureName ?? throw new ArgumentNullException(nameof(procedureName));
        }
    }
}



