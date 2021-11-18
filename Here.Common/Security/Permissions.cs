using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Common.Security
{
  public static class Permissions
  {
    public static class Company
    {
      public static string VIEW = $"{CustomClaimTypes.PERMISSION}.{nameof(Company)}.View";
      public static string CREATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Company)}.Create";
      public static string UPDATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Company)}.Update";
      public static string DELETE = $"{CustomClaimTypes.PERMISSION}.{nameof(Company)}.Delete";
    }

    public static class Employee
    {
      public static string VIEW = $"{CustomClaimTypes.PERMISSION}.{nameof(Employee)}.View";
      public static string CREATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Employee)}.Create";
      public static string UPDATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Employee)}.Update";
      public static string DELETE = $"{CustomClaimTypes.PERMISSION}.{nameof(Employee)}.Delete";
    }

    public static class Event
    {
      public static string VIEW = $"{CustomClaimTypes.PERMISSION}.{nameof(Event)}.View";
      public static string CREATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Event)}.Create";
      public static string UPDATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Event)}.Update";
      public static string DELETE = $"{CustomClaimTypes.PERMISSION}.{nameof(Event)}.Delete";
    }

    public static class EventType
    {
      public static string VIEW = $"{CustomClaimTypes.PERMISSION}.{nameof(EventType)}.View";
      public static string CREATE = $"{CustomClaimTypes.PERMISSION}.{nameof(EventType)}.Create";
      public static string UPDATE = $"{CustomClaimTypes.PERMISSION}.{nameof(EventType)}.Update";
      public static string DELETE = $"{CustomClaimTypes.PERMISSION}.{nameof(EventType)}.Delete";
    }

    public static class Rule
    {
      public static string VIEW = $"{CustomClaimTypes.PERMISSION}.{nameof(Rule)}.View";
      public static string CREATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Rule)}.Create";
      public static string UPDATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Rule)}.Update";
      public static string DELETE = $"{CustomClaimTypes.PERMISSION}.{nameof(Rule)}.Delete";
    }

    public static class Shift
    {
      public static string VIEW = $"{CustomClaimTypes.PERMISSION}.{nameof(Shift)}.View";
      public static string CREATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Shift)}.Create";
      public static string UPDATE = $"{CustomClaimTypes.PERMISSION}.{nameof(Shift)}.Update";
      public static string DELETE = $"{CustomClaimTypes.PERMISSION}.{nameof(Shift)}.Delete";
    }
  }
}
