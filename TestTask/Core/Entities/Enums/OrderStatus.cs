using System.Runtime.Serialization;

namespace Core.Entities.Enums;

public enum OrderStatus
{
  [EnumMember(Value = "New")]
  New,

  [EnumMember(Value = "Paid")]
  Paid,

  [EnumMember(Value = "Shipped")]
  Shipped,

  [EnumMember(Value = "Delivered")]
  Delivered,

  [EnumMember(Value = "Closed")]
  Closed
}