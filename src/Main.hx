import solutions.*;

class Main {
    static var elapsedTime:Float = 0;

    static function main() {
        solveDay(Sys.args()[0]);
    }

    static function solveDay(arg:String) {
        while (!runDaySolver(arg)) {
            Sys.println("No day found. Input a solved day: ");
            arg = Sys.stdin().readLine();
        }
        Sys.println(elapsedTime * 1000 + ' ms');
    }

    static function runDaySolver(day:String):Bool {
        elapsedTime = Sys.time();
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
            default: return false;
        }
        elapsedTime = Sys.time() - elapsedTime;
        return true;
    }
}