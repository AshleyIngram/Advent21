module Day3

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Calculates the correct power consumption`` () =
    seq { "00100"; "11110"; "10110"; "10111"; "10101"; "01111"; "00111"; "11100"; "10000"; "11001"; "00010"; "01010" } |> Advent21.Day3.part1 |> should equal 198

[<Fact>]
let ``Calculates the life support rating of the submarine`` () =
    seq { "00100"; "11110"; "10110"; "10111"; "10101"; "01111"; "00111"; "11100"; "10000"; "11001"; "00010"; "01010" } |> Advent21.Day3.part2 |> should equal 230