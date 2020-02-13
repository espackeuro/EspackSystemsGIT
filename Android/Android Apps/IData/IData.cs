using System.Threading.Tasks;


namespace IData
{
    public enum dataStatus { NONE, WARNING, ERROR, READ, DATABASE, TRANSMITTED }
    public interface IExtendedRecord
    {
        int IdReg { get; set; }
        bool Transferred { get; set; }
        dataStatus Status { get; set; }
        string ProcedureParameters();
    }
}



