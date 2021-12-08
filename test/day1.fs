module Day1

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Counts the number of times a depth measurement increases`` () =
    seq { 199; 200; 208; 210; 200; 207; 240; 269; 260; 263 } |> Advent21.Day1.part1 |> should equal 7