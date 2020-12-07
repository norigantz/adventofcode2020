import solutions.*;

class Main {
    static function main() {
        solveDay(Sys.args()[0]);
    }

    static function solveDay(arg:String) {
        while (!runDaySolver(arg)) {
            Sys.println("No day found. Input a solved day: ");
            arg = Sys.stdin().readLine();
        }
    }

    static function runDaySolver(day:String):Bool {
        switch day {
            case "1": Day1.solve();
            case "2": Day2.solve();
            case "3": Day3.solve();
            case "4": Day4.solve();
            case "5": Day5.solve();
            case "6": Day6.solve();
            case "7": Day7.solve();
            default: return false;
        }
        return true;
    }
}