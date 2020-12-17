import solutions.*;

class Main {
    static var elapsedTimes:Map<String, Float> = new Map<String, Float>();

    static function main() {
        solveDay(Sys.args()[0]);
    }

    static function solveDay(arg:String) {
        while (!runDaySolver(arg)) {
            Sys.println("No day found. Input a solved day: ");
            arg = Sys.stdin().readLine();
        }
        // Sys.println((elapsedTime*1000) + ' ms');
        for (key in elapsedTimes.keys())
            Sys.println('Day ' + key + ': ' + (elapsedTimes[key]*1000) + ' ms');
    }

    static function runDaySolver(day:String):Bool {
        var elapsedTime = Sys.time();
        switch day {
            case "1": Day1.solve();
            case "2": Day2.solve();
            case "3": Day3.solve();
            case "4": Day4.solve();
            case "5": Day5.solve();
            case "6": Day6.solve();
            case "7": Day7.solve();
            case "8": Day8.solve();
            case "9": Day9.solve();
            case "10": Day10.solve();
            case "11": Day11.solve();
            case "12": Day12.solve();
            case "13": Day13.solve();
            case "14": Day14.solve();
            case "15": Day15.solve();
            case "16": Day16.solve();
            case "17": Day17.solve();
            case "all":
                elapsedTime = Sys.time();
                Day1.solve();
                elapsedTimes["1"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day2.solve();
                elapsedTimes["2"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day3.solve();
                elapsedTimes["3"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day4.solve();
                elapsedTimes["4"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day5.solve();
                elapsedTimes["5"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day6.solve();
                elapsedTimes["6"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day7.solve();
                elapsedTimes["7"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day8.solve();
                elapsedTimes["8"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day9.solve();
                elapsedTimes["9"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day10.solve();
                elapsedTimes["10"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day11.solve();
                elapsedTimes["11"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day12.solve();
                elapsedTimes["12"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day13.solve();
                elapsedTimes["13"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day14.solve();
                elapsedTimes["14"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day15.solve();
                elapsedTimes["15"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day16.solve();
                elapsedTimes["16"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Day17.solve();
                elapsedTimes["17"] = (Sys.time() - elapsedTime);
                elapsedTime = Sys.time();
                Sys.println('');
            default: return false;
        }
        elapsedTimes[day] = Sys.time() - elapsedTime;
        return true;
    }
}