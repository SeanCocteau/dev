public class myDataObject{

    public myDataObject( Guid id, int numeric ){
        DataId = id;
        DataNumeric = numeric;
    }

    public Guid DataId { get; set; }
    public int DataNumeric { get; set; }

}