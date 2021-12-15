namespace Advent21

module Day2 =  
    type Position = { Horizontal: int; Depth: int; }
    type Direction = { Direction: string; Value: int; }
    
    let part1 (inputStrings: seq<string>) =
        let tryToInt (s: string) = 
            match System.Int32.TryParse s with
            | true, v -> Some v
            | false, _ -> None

        let (|Instruction|_|) (s: string) =
            let parts = s.Split(' ')

            if (parts.Length <> 2 || Option.isNone (tryToInt parts.[1])) then None else
                let value = int parts.[1]
                match parts.[0] with
                | "forward" -> Some ({ Direction = "forward"; Value = value })
                | "up" -> Some ({ Direction = "up"; Value = value })
                | "down" -> Some ({ Direction = "down"; Value = value })
                | _ -> None

        let initialState = { Horizontal = 0; Depth = 0; }
        let instructions = inputStrings |> Seq.map (fun i ->
            match i with
            | Instruction i -> i
            | _ -> raise <| invalidArg "instruction" i
        )

        (initialState, instructions) ||> Seq.fold (fun state instruction -> 
            match instruction.Direction with
            | "forward" -> { Horizontal = state.Horizontal + instruction.Value; Depth = state.Depth }
            | "up" -> { Horizontal = state.Horizontal; Depth = state.Depth - instruction.Value }
            | "down" ->  { Horizontal = state.Horizontal; Depth = state.Depth + instruction.Value }
            | _ -> raise <| invalidArg "instruction" instruction.Direction
        )
        |> (fun state -> state.Horizontal * state.Depth) 
