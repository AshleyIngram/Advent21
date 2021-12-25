namespace Advent21

module Day3 =  
    open System
    open System.Collections
    
    let private parseInput (input: seq<string>) =
        input |> Seq.map (fun i -> new BitArray([| Convert.ToInt32(i, 2) |]))

    let private mostFrequent s =
        s
        |> Seq.countBy id
        |> Seq.maxBy snd
        |> fst

    let private mostFrequentBit (bitArrays: seq<BitArray>) (digitPosition: int) =
        bitArrays |> Seq.map (fun bv -> bv.[digitPosition]) |> mostFrequent
    
    let toInt (bitArray: BitArray) =
        let (result: int32 array) = Array.zeroCreate 1
        bitArray.CopyTo(result, 0)
        result[0];

    let part1 (inputStrings: seq<string>) =
        let numbers = parseInput inputStrings
        let bits = (inputStrings |> Seq.head).Length
        let gammaArray = { 0 .. bits - 1 } |> Seq.map (mostFrequentBit numbers)
        let epilsonArray = gammaArray |> Seq.map (fun g -> not g)
        let gamma = new BitArray(gammaArray |> Seq.toArray) |> toInt
        let epilson = new BitArray(epilsonArray |> Seq.toArray) |> toInt

        gamma * epilson