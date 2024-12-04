namespace OrbitDataShark.DataGen.Models;

public class TableGenerationResult
{
    public string TableName { get; set; }
    public ObjectProxy Result { get; set; }

    public TableGenerationResult( string tableName, ObjectProxy result)
    {
        TableName = tableName;
        Result = result;
    }
}