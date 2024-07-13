using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.Graphs
{
    public class Graph
    {
        public static HashSet<Node<string>> AllNodes { get; set; } = new HashSet<Node<string>>();


        public static Node<string> GetGraph()
        {
            // f to e
            // j to o
            // i to m to l
            // g to b

            "A".ConnectsTo("B")
                .ConnectsTo("F")
                .ConnectsTo("J")
                .ConnectsTo("N")
                .ConnectsTo("C")
                .ConnectsTo("A")
                .ConnectsTo("D")
                .ConnectsTo("H")
                .ConnectsTo("I")
                .ConnectsTo("L")
                .ConnectsTo("G")
                .ConnectsTo("K")
                .ConnectsTo("Q")
                .ConnectsTo("P");
            "F".ConnectsTo("E");
            "J".ConnectsTo("O");
            "I".ConnectsTo("M").ConnectsTo("L");
            "G".ConnectsTo("B");

            return AllNodes.Single(n => n.Payload == "A");
        }
    }
}
