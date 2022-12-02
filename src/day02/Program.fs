namespace Day2

open System.IO

module Functions = 

  let injest (filePath: string): seq<string> = File.ReadLines(filePath)

  let convert (move: string): char = 
    let moves = Map[("A", 'R'); ("B", 'P'); ("C",'S'); ("X", 'R'); ("Y", 'P'); ("Z",'S')]
    moves.[move]
  
  let parse (line: string): char*char =
    let parsed =
      line.Split " " 
      |> Array.toList
      |> List.map(fun move -> convert move)
    (parsed[0],parsed[1])

  let convert2 (move: string): char = 
    let moves = Map[("A", 'R'); ("B", 'P'); ("C",'S'); ("X", 'L'); ("Y", 'D'); ("Z",'W')]
    moves.[move]
  
  let getMove (line: char*char): char =
    match snd line with
      | 'L' -> 
        match fst line with
          | 'P' -> 'R'
          | 'R' -> 'S'
          | 'S' -> 'P'
      | 'D' -> fst line
      | 'W' -> 
        match fst line with
          | 'P' -> 'S'
          | 'R' -> 'P'
          | 'S' -> 'R'

  let parse2 (line: string): char*char =
    let parsed =
      line.Split " " 
      |> Array.toList
      |> List.map(fun move -> convert2 move)
    (parsed[0],parsed[1])

  let play (played: char*char): int = 
    match played with
      | ('P','S') -> 6 // Specific Win
      | ('S','P') -> 0 // Specific Loss
      | (them, you) when them = you -> 3 // Draw
      | (them, you) when them < you -> 0 // Loss
      | (them, you) when them > you -> 6 // Win

  let score (played: char*char): int =
    match played with
      | (_,'R') -> 1
      | (_,'P') -> 2
      | (_,'S') -> 3

module Program = 
  [<EntryPoint>] 
  let main args = 
    let firstScore = 
      Functions.injest "input.txt" 
      |> Seq.map (fun line -> Functions.parse line)
      |> Seq.map (fun played -> printfn $"{(Functions.score played) + (Functions.play played)}"; (Functions.score played) + (Functions.play played))
      |> Seq.sum

    let secondScore = 
      Functions.injest "input.txt" 
      |> Seq.map (fun line -> Functions.parse2 line)
      |> Seq.map (fun line -> (fst line, Functions.getMove line))
      |> Seq.map (fun played -> printfn $"{(Functions.score played) + (Functions.play played)}"; (Functions.score played) + (Functions.play played))
      |> Seq.sum

    printfn $"For the first run our total score is {firstScore}"
    printfn $"For the second run our total score is {secondScore}"

    0
