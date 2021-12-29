namespace Advent21

module Day3 =
    open System
    open System.Collections

    let private parseInput (input: seq<string>) =
        input |> Seq.map (fun i -> new BitArray([| Convert.ToInt32(i, 2) |]))

    let private toInt (bitArray: BitArray) =
        let (result: int32 array) = Array.zeroCreate 1
        bitArray.CopyTo(result, 0)
        result.[0]

    let private mostFrequent (s: seq<bool>) =
        let counts = s |> Seq.countBy id |> Map.ofSeq

        if counts.[false] > counts.[true] then
            false
        else
            true

    let private mostFrequentBit (bitArrays: seq<BitArray>) (digitPosition: int) =
        bitArrays
        |> Seq.map (fun bv -> bv.[digitPosition])
        |> mostFrequent

    let rec private reduceToOne (collection: seq<'a>) (filter: int -> seq<'a> -> seq<'a>) (iteration: int) =
        let result = filter iteration collection

        match (result |> Seq.length) with
        | 1 -> result |> Seq.head
        | _ -> reduceToOne result filter (iteration - 1)

    let private only targetPosition (bitArrays: seq<BitArray>) func =
        bitArrays |> Seq.filter (fun ba -> ba.[targetPosition] = func)

    let private onlyMostFrequent targetPosition bitArrays =
        let mostFrequent = mostFrequentBit bitArrays targetPosition
        only targetPosition bitArrays mostFrequent

    let private onlyLeastFrequent targetPosition bitArrays =
        let leastFrequent = not (mostFrequentBit bitArrays targetPosition)
        only targetPosition bitArrays leastFrequent

    let part1 (inputStrings: seq<string>) =
        let numbers = parseInput inputStrings
        let bits = (inputStrings |> Seq.head).Length

        let gammaArray = { 0 .. bits - 1 } |> Seq.map (mostFrequentBit numbers)
        let gamma = new BitArray(gammaArray |> Seq.toArray) |> toInt

        let epilsonArray = gammaArray |> Seq.map (fun g -> not g)
        let epilson = new BitArray(epilsonArray |> Seq.toArray) |> toInt

        gamma * epilson

    let part2 (inputStrings: seq<string>) =
        let numbers = parseInput inputStrings
        let bits = (inputStrings |> Seq.head).Length - 1

        let oxygen = reduceToOne numbers onlyMostFrequent bits |> toInt
        let co2Scrubber = reduceToOne numbers onlyLeastFrequent bits |> toInt

        oxygen * co2Scrubber
