
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models;

[BsonIgnoreExtraElements]
public class PaymentCard
{
  
    public int PaymentDetailId{get;set;}
 
    public string CardHolderName {get;set;} = string.Empty;
 

    public string CardNumber {get;set;}=string.Empty;
 

    public string expairyDate {get;set;}=string.Empty;
 

    public string SecurityCode{get;set;}=string.Empty;
}
