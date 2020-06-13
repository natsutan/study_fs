// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.
open FSharp.Charting
let path = @"C:\home\myproj\study_fs\expertfs4\chap10\fig\"

let drawPoint =
    let rnd = System.Random()
    let rand() = rnd.NextDouble()
    
    let randomPoints = [for i in 0 .. 1000 -> 10.0 * rand(), 10.0 * rand() ]
    let chart =  Chart.Point randomPoints
    let output_file = path + @"point.png" 
    Chart.Save output_file chart
        
    printf "%s\n"  output_file

let drawCombileChart =
    let rnd = System.Random()
    let rand() = rnd.NextDouble()
    let randomTrend1 = [for i in 0.0 .. 0.1 .. 10.0 -> i, sin i + rand()]
    let randomTrend2 = [for i in 0.0 .. 0.1 .. 10.0 -> i, sin i + rand()]
    let c1 = Chart.Line(randomTrend1, Title = "Random Trend")
    let chart = Chart.Combine [c1 ; Chart.Line randomTrend2]
    let output_file = path + @"trend.png"    
    Chart.Save output_file chart
    
    printf "%s\n"  output_file




[<EntryPoint>]
let main argv =
    drawPoint |> ignore
    drawCombileChart |> ignore

    0 // return an integer exit code
