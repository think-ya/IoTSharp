﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTSharp.Models.Rule
{
    public class Activity
    {
        public long RuleId { get; set; }
        public string DefinitionsDesc { get; set; }
        public string DefinitionsName { get; set; }
        public int DefinitionsStatus { get; set; }
        public List<Task> Tasks { get; set; }
        public List<GateWay> GateWays { get; set; }

        public List<SequenceFlow> SequenceFlows { get; set; }
        public List<BpmnBaseObject> LaneSet { get; set; }
        public List<BpmnBaseObject> EndEvents { get; set; }
        public List<BpmnBaseObject> StartEvents { get; set; }
        public List<BpmnBaseObject> Containers { get; set; }
        public List<BpmnBaseObject> BaseBpmnObjects { get; set; }

        public List<BpmnBaseObject> DataStoreReferences { get; set; }
        public List<BpmnBaseObject> SubProcesses { get; set; }
        public List<BpmnBaseObject> DataOutputAssociations { get; set; }
        public List<BpmnBaseObject> DataInputAssociations { get; set; }
        public List<BpmnBaseObject> Lane { get; set; }
        public List<BpmnBaseObject> TextAnnotations { get; set; }

    }
    public class Task : BpmnBaseObject
    {
    
    }
    public class SequenceFlow : BpmnBaseObject
    {
        public string sourceId { get; set; }
        public string targetId { get; set; }


    }
    public class GateWay : BpmnBaseObject
    {
        public string sourceId { get; set; }
        public string targetId { get; set; }
    }


    public class BpmnBaseObject
    {
        public string Flowname { get; set; }
        public string id { get; set; }
        public BpmnBaseObject[] incoming { get; set; }
        public BpmnBaseObject[] outgoing { get; set; }
        public FormBpmnObject BizObject { get; set; }
        public string bpmntype { get; set; }

    }

    public class FormBpmnObject
    {
        public string Flowid { get; set; }
        public string Flowname { get; set; }
        public string Flowdesc { get; set; }
        public string Flowtype { get; set; }
        public string NodeProcessClass { get; set; }
        public string conditionexpression { get; set; }
        public string NodeProcessParams { get; set; }
        public string flowscript { get; set; }
        public string flowscripttype { get; set; }
    }

}
