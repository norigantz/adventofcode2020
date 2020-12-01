import solutions.*;

class Main {
    static function main() {
        solveDay(Sys.args()[0]);
    }

    static function solveDay(day:String) {
        switch day {
            case "1": Day1.solve();
            case "2": Sys.println("Solving day 2");
            default: Sys.println("No day provided");
        }
    }
}