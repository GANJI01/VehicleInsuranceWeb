using System;
using System.Collections.Generic;

namespace ABZClaimsLibrary.Models;

public partial class Claim
{
    public string ClaimNo { get; set; } = null!;

    public DateTime? ClaimDate { get; set; }

    public string PolicyNo { get; set; } = null!;

    public DateTime IncidentDate { get; set; }

    public string IncidentLocation { get; set; } = null!;

    public string? IncidentDescription { get; set; }

    public decimal ClaimAmount { get; set; }

    public string SurveyorName { get; set; } = null!;

    public string SurveyorPhone { get; set; } = null!;

    public DateTime? SurveyDate { get; set; }

    public string? SurveyDescription { get; set; }

    public string ClaimStatus { get; set; } = null!;

    public virtual Policy? PolicyNoNavigation { get; set; } = null!;
}
