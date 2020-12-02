import solutions.*;

class Main {
    static function main() {
        solveDay(Sys.args()[0]);
    }

    static function solveDay(arg:String) {
        switch arg {
            case "1": Day1.solve();
            case "2": Day2.solve();
            default: Sys.println("No day found");
        }
    }
}