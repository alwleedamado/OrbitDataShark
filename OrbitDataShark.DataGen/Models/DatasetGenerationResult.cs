namespace OrbitDataShark.DataGen.Models;

public class DatasetGenerationResult
{
    public DatasetGenerationResult(string datasetName)
    {
        DatasetName = datasetName;
    }

    public string DatasetName { get; set; }
    public IList<TableGenerationResult> Tables { get; set; } = new List<TableGenerationResult>();
}