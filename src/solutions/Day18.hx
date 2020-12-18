package solutions;

import haxe.Int64;
using StringTools;

class Day18 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day18.txt');

    public static function solve() {
        Sys.println("Solving Day18");
        var arr:Array<String> = input.split('\r\n');

        var sum:Int64 = 0;
        for (i in 0...arr.length) {
            Sys.println(i + ': ' + arr[i]);
            if (evaluate(arr[i]) < 0)
                break;
            sum += evaluate(arr[i]);
        }
        Sys.println('b: ' + sum);
        // Sys.println(evaluate(arr[5]));
    }

    static function evaluate(expression:String):Int64 {
        expression = expression.replace(' ', '');
        Sys.println(expression);

        var parens = 0;
        var subExpression = '';
        var ereg = ~/[(]/;
        while(ereg.match(expression)) {
            for (i in 0...expression.length) {
                if (expression.charAt(i) == '(')
                    parens++;
                if (parens > 0)
                    subExpression += expression.charAt(i);
                if (expression.charAt(i) == ')') {
                    parens--;
                    if(parens == 0) {
                        Sys.println(subExpression);
                        expression = expression.replace(subExpression, ''+evaluate(subExpression.substr(1, subExpression.length-2)));
                        Sys.println(expression);
                        subExpression = '';
                        break;
                    }
                }
            }
        }
        
        ereg = ~/[+]/;
        var currExpression = expression;
        var result:Int64 = 0;
        while (ereg.match(currExpression)) {
            var left:Int64;
            var leftReg = ~/[+*]/;
            if (leftReg.match(ereg.matchedLeft())) {
                var matchForward = ereg.matchedLeft();
                while (leftReg.match(matchForward))
                    matchForward = leftReg.matchedRight();
                left = Int64.parseString(leftReg.matchedRight());
                Sys.println('left: '+ left);
            }
            else {
                left = Int64.parseString(ereg.matchedLeft());
                Sys.println('left: '+ left);
            }
            var op = ereg.matched(0);
            var right:Int64;
            var rightReg = ~/[+*]/;
            if (rightReg.match(ereg.matchedRight()))
                right = Int64.parseString(rightReg.matchedLeft());
            else
                right = Int64.parseString(ereg.matchedRight());
            Sys.println(left);
            Sys.println(op);
            Sys.println(right);
            
            result = left + right;
            Sys.println('='+result);
            Sys.println('');
            currExpression = currExpression.substr(0, currExpression.indexOf(left+op+right)) + result + currExpression.substr(currExpression.indexOf(left+op+right)+(left+op+right).length);
        }

        Sys.println('curr: ' + currExpression);
        ereg = ~/[*]/;
        while (ereg.match(currExpression)) {
            var left:Int64;
            var leftReg = ~/[*]/;
            if (leftReg.match(ereg.matchedLeft())) {
                var matchForward = ereg.matchedLeft();
                while (leftReg.match(matchForward))
                    matchForward = leftReg.matchedRight();
                left = Int64.parseString(leftReg.matchedRight());
                Sys.println('left: '+ left);
            }
            else {
                left = Int64.parseString(ereg.matchedLeft());
                Sys.println('left: '+ left);
            }
            var op = ereg.matched(0);
            var right:Int64;
            var rightReg = ~/[+*]/;
            if (rightReg.match(ereg.matchedRight()))
                right = Int64.parseString(rightReg.matchedLeft());
            else
                right = Int64.parseString(ereg.matchedRight());
            Sys.println(left);
            Sys.println(op);
            Sys.println(right);
            
            result = left * right;
            Sys.println('='+result);
            Sys.println('');
            currExpression = result + currExpression.substr(currExpression.indexOf(left+op+right)+(left+op+right).length);
        }
        return result;
    }
}