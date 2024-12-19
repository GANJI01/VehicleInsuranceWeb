using System;
using System.Collections.Generic;

namespace ABZAgentLibrary.Models;

public partial class Agent
{
    public string AgentID { get; set; } = null!;

    public string AgentName { get; set; } = null!;

    public string AgentPhone { get; set; } = null!;

    public string AgentEmail { get; set; } = null!;

    public string LicenseCode { get; set; } = null!;
}
