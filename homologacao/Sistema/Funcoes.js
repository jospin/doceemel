<!--

// VARIABLE DECLARATIONS
var digits						= "0123456789";
var lowercaseLetters			= "abcdefghijklmnopqrstuvwxyz"
var uppercaseLetters			= "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

// whitespace characters
var whitespace = " \t\n\r";

// decimal point character differs by language and culture
var decimalPointDelimiter = ","

// Ponto de milhar
var milharPointDelimiter = "."

// non-digit characters which are allowed in phone numbers
var phoneNumberDelimiters = "()- ";

var defaultEmptyOK = false

//Variável para verificar se clicou no checkbox ou na celula;
var bOrigemChk = 0;

// Variável Utilizada em fnAtivaDesativaLista
var bAtivaCheckBox			= true; 
var bAtivaCheckBoxStatus	= true; 
function makeArray(n) {
//*** BUG: If I put this line in, I get two error messages:
//(1) Window.length can't be set by assignment
//(2) daysInMonth has no property indexed by 4
//If I leave it out, the code works fine.
//   this.length = n;
   for (var i = 1; i <= n; i++) {
      this[i] = 0
   } 
   return this
}

var daysInMonth = makeArray(12);
daysInMonth[1] = 31;
daysInMonth[2] = 29;   // must programmatically check this
daysInMonth[3] = 31;
daysInMonth[4] = 30;
daysInMonth[5] = 31;
daysInMonth[6] = 30;
daysInMonth[7] = 31;
daysInMonth[8] = 31;
daysInMonth[9] = 30;
daysInMonth[10] = 31;
daysInMonth[11] = 30;
daysInMonth[12] = 31;


// Check whether string s is empty.

function isEmpty(s)
{   return ((s == null) || (s.length == 0))
}


// Returns true if string s is empty or 
// whitespace characters only.

function isWhitespace (s)

{   var i;

    // Is s empty?
    if (isEmpty(s)) return true;

    // Search through string's characters one by one
    // until we find a non-whitespace character.
    // When we do, return false; if we don't, return true.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character isn't whitespace.
        var c = s.charAt(i);

        if (whitespace.indexOf(c) == -1) return false;
    }

    // All characters are whitespace.
    return true;
}


// Removes all characters which appear in string bag from string s.

function stripCharsInBag (s, bag)

{   var i;
    var returnString = "";

    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }

    return returnString;
}


// Removes all characters which do NOT appear in string bag 
// from string s.

function stripCharsNotInBag (s, bag)

{   var i;
    var returnString = "";

    // Search through string's characters one by one.
    // If character is in bag, append to returnString.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (bag.indexOf(c) != -1) returnString += c;
    }

    return returnString;
}


// Removes all whitespace characters from s.
// Global variable whitespace (see above)
// defines which characters are considered whitespace.

function stripWhitespace (s)

{   return stripCharsInBag (s, whitespace)
}


function replace(expressao, encontrar, substituir){

	var sExpressaoRetorno = "";
	expressao = expressao + "";
	
	var arrExpressao = expressao.split(encontrar);
	
	for (var cont=0;cont<arrExpressao.length;cont++){
		sExpressaoRetorno = sExpressaoRetorno + arrExpressao[cont] + substituir;
	}
	
	return sExpressaoRetorno.substring(0,sExpressaoRetorno.length - substituir.length);
}

function right(expressao,tamanho){
	
	var inicio = expressao.length - tamanho;
	return expressao.substring(inicio,expressao.length);
	
}

function left(expressao,tamanho){
	
	return expressao.substring(0,tamanho);
	
}

function charInString (c, s)
{   for (i = 0; i < s.length; i++)
    {   if (s.charAt(i) == c) return true;
    }
    return false
}



// Removes initial (leading) whitespace characters from s.
// Global variable whitespace (see above)
// defines which characters are considered whitespace.

function stripInitialWhitespace (s)

{   var i = 0;

    while ((i < s.length) && charInString (s.charAt(i), whitespace))
       i++;
    
    return s.substring (i, s.length);
}


function isLetter (c)
{   return ( ((c >= "a") && (c <= "z")) || ((c >= "A") && (c <= "Z")) )
}



function isDigit (c)
{   return ((c >= "0") && (c <= "9"))
}


// Returns true if character c is a letter or digit.

function isLetterOrDigit (c)
{   return (isLetter(c) || isDigit(c))
}



// isInteger (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if all characters in string s are numbers.
//
// Accepts non-signed integers only. Does not accept floating 
// point, exponential notation, etc.
//
// We don't use parseInt because that would accept a string
// with trailing non-numeric characters.
//
// By default, returns defaultEmptyOK if s is empty.
// There is an optional second argument called emptyOK.
// emptyOK is used to override for a single function call
//      the default behavior which is specified globally by
//      defaultEmptyOK.
// If emptyOK is false (or any value other than true), 
//      the function will return false if s is empty.
// If emptyOK is true, the function will return true if s is empty.
//
// EXAMPLE FUNCTION CALL:     RESULT:
// isInteger ("5")            true 
// isInteger ("")             defaultEmptyOK
// isInteger ("-5")           false
// isInteger ("", true)       true
// isInteger ("", false)      false
// isInteger ("5", false)     true

function isInteger (s)

{   var i;

    if (isEmpty(s)) 
       if (isInteger.arguments.length == 1) return defaultEmptyOK;
       else return (isInteger.arguments[1] == true);

    // Search through string's characters one by one
    // until we find a non-numeric character.
    // When we do, return false; if we don't, return true.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is number.
        var c = s.charAt(i);

        if (!isDigit(c)) return false;
    }

    // All characters are numbers.
    return true;
}



// isSignedInteger (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if all characters are numbers; 
// first character is allowed to be + or - as well.
//
// Does not accept floating point, exponential notation, etc.
//
// We don't use parseInt because that would accept a string
// with trailing non-numeric characters.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.
//
// EXAMPLE FUNCTION CALL:          RESULT:
// isSignedInteger ("5")           true 
// isSignedInteger ("")            defaultEmptyOK
// isSignedInteger ("-5")          true
// isSignedInteger ("+5")          true
// isSignedInteger ("", false)     false
// isSignedInteger ("", true)      true

function isSignedInteger (s)

{   if (isEmpty(s)) 
       if (isSignedInteger.arguments.length == 1) return defaultEmptyOK;
       else return (isSignedInteger.arguments[1] == true);

    else {
        var startPos = 0;
        var secondArg = defaultEmptyOK;

        if (isSignedInteger.arguments.length > 1)
            secondArg = isSignedInteger.arguments[1];

        // skip leading + or -
        if ( (s.charAt(0) == "-") || (s.charAt(0) == "+") )
           startPos = 1;    
        return (isInteger(s.substring(startPos, s.length), secondArg))
    }
}


// isPositiveInteger (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if string s is an integer > 0.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function isPositiveInteger (s)
{   var secondArg = defaultEmptyOK;

    if (isPositiveInteger.arguments.length > 1)
        secondArg = isPositiveInteger.arguments[1];

    // The next line is a bit byzantine.  What it means is:
    // a) s must be a signed integer, AND
    // b) one of the following must be true:
    //    i)  s is empty and we are supposed to return true for
    //        empty strings
    //    ii) this is a positive, not negative, number

    return (isSignedInteger(s, secondArg)
         && ( (isEmpty(s) && secondArg)  || (parseInt (s) > 0) ) );
}


// isNonnegativeInteger (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if string s is an integer >= 0.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function isNonnegativeInteger (s)
{   var secondArg = defaultEmptyOK;

    if (isNonnegativeInteger.arguments.length > 1)
        secondArg = isNonnegativeInteger.arguments[1];

    // The next line is a bit byzantine.  What it means is:
    // a) s must be a signed integer, AND
    // b) one of the following must be true:
    //    i)  s is empty and we are supposed to return true for
    //        empty strings
    //    ii) this is a number >= 0

    return (isSignedInteger(s, secondArg)
         && ( (isEmpty(s) && secondArg)  || (parseInt (s) >= 0) ) );
}

// isNegativeInteger (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if string s is an integer < 0.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function isNegativeInteger (s)
{   var secondArg = defaultEmptyOK;

    if (isNegativeInteger.arguments.length > 1)
        secondArg = isNegativeInteger.arguments[1];

    // The next line is a bit byzantine.  What it means is:
    // a) s must be a signed integer, AND
    // b) one of the following must be true:
    //    i)  s is empty and we are supposed to return true for
    //        empty strings
    //    ii) this is a negative, not positive, number

    return (isSignedInteger(s, secondArg)
         && ( (isEmpty(s) && secondArg)  || (parseInt (s) < 0) ) );
}


// isNonpositiveInteger (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if string s is an integer <= 0.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function isNonpositiveInteger (s)
{   var secondArg = defaultEmptyOK;

    if (isNonpositiveInteger.arguments.length > 1)
        secondArg = isNonpositiveInteger.arguments[1];

    // The next line is a bit byzantine.  What it means is:
    // a) s must be a signed integer, AND
    // b) one of the following must be true:
    //    i)  s is empty and we are supposed to return true for
    //        empty strings
    //    ii) this is a number <= 0

    return (isSignedInteger(s, secondArg)
         && ( (isEmpty(s) && secondArg)  || (parseInt (s) <= 0) ) );
}

// isFloat (STRING s [, BOOLEAN emptyOK])
// 
// True if string s is an unsigned floating point (real) number. 
//
// Also returns true for unsigned integers. If you wish
// to distinguish between integers and floating point numbers,
// first call isInteger, then call isFloat.
//
// Does not accept exponential notation.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function isFloat (s)

{   var i;
    var seenDecimalPoint = false;

    if (isEmpty(s)) 
       if (isFloat.arguments.length == 1) return defaultEmptyOK;
       else return (isFloat.arguments[1] == true);

    if (s == decimalPointDelimiter) return false;

	if (s.indexOf(milharPointDelimiter) != -1) {
		var arrCasas = s.split(milharPointDelimiter);

		var count;
		for (count = 0;count < arrCasas.length;count++){
			if (count == 0){
				if (arrCasas[count].length > 3 || arrCasas[count].length == 0){
					return false;
				}
			}
			else if (count == arrCasas.length - 1){
				if (arrCasas[count].indexOf(decimalPointDelimiter) == -1){
					if (arrCasas[count].length != 3){
						return false;
					}
				}
				else if (arrCasas[count].indexOf(decimalPointDelimiter) != 3){
					return false;
				}
			}
			else{
				if (arrCasas[count].length != 3 || !isInteger(arrCasas[count])){
					return false;
				}
			}				
		}
		s = stripCharsInBag(s,milharPointDelimiter);
	}

    // Search through string's characters one by one
    // until we find a non-numeric character.
    // When we do, return false; if we don't, return true.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is number.
        var c = s.charAt(i);

        if ((c == decimalPointDelimiter) && !seenDecimalPoint) seenDecimalPoint = true;
        else if (!isDigit(c)) return false;
    }

    // All characters are numbers.
    return true;
}

//function que verifica se um caracter esta em um determinado range
//par:valor - valor do objeto
//range - range de valores permitidos pelo objeto
//msg - msg a ser mostrada em caso de erro
//mostra - '1' se mostra msg 
//retorno:boleano
//
function verificaValor(valor,range,msg,mostra){
  var resp=true;
  for(var i=0;i<valor.length;i++){
    if (range.indexOf(valor.charAt(i))==-1){
      resp=false;
      i=valor.length;
    }
  }
  if (!resp && mostra=='1')
    alert(msg);
  
  return resp;
}



// isSignedFloat (STRING s [, BOOLEAN emptyOK])
// 
// True if string s is a signed or unsigned floating point 
// (real) number. First character is allowed to be + or -.
//
// Also returns true for unsigned integers. If you wish
// to distinguish between integers and floating point numbers,
// first call isSignedInteger, then call isSignedFloat.
//
// Does not accept exponential notation.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function isSignedFloat (s)

{   if (isEmpty(s)) 
       if (isSignedFloat.arguments.length == 1) return defaultEmptyOK;
       else return (isSignedFloat.arguments[1] == true);

    else {
        var startPos = 0;
        var secondArg = defaultEmptyOK;

        if (isSignedFloat.arguments.length > 1)
            secondArg = isSignedFloat.arguments[1];

        // skip leading + or -
        if ( (s.charAt(0) == "-") || (s.charAt(0) == "+") )
           startPos = 1;    
        return (isFloat(s.substring(startPos, s.length), secondArg))
    }
}

function fnConsisteTamanhoDecimal(Numero,iQtdInteiros,iQtdDecimais){
	
	var sDigitoDecimalEntrada = "";
	var aNumero;
	
	//Converte o numero para string
	Numero =  Numero + "";

	if (Numero.indexOf(",") < Numero.indexOf(".") && Numero.indexOf(".") < Numero.lastIndexOf(",")) return false;	
	if (Numero.indexOf(".") < Numero.indexOf(",") && Numero.indexOf(",") < Numero.lastIndexOf(".")) return false;

	//Obtem o caracter separador de decimal e retira os de milhar
	var iPosVirgula = Numero.indexOf(",");
	var iPosPonto = Numero.indexOf(".");
	if (iPosVirgula > iPosPonto && iPosPonto != -1){
		Numero = replace(Numero,".","")
		sDigitoDecimalEntrada = ",";
	}else if (iPosVirgula < iPosPonto && iPosVirgula != -1){
		Numero = replace(Numero,",","")
		sDigitoDecimalEntrada = ".";
	}else if (iPosVirgula > -1 && iPosPonto == -1){
		sDigitoDecimalEntrada = ",";
	}else if (iPosPonto > -1 && iPosVirgula == -1){
		if(iQtdDecimais == 0){
			sDigitoDecimalEntrada = "";
		}else{
			sDigitoDecimalEntrada = ".";
		}
	}else{
		sDigitoDecimalEntrada = "";
	}
	//Subistitui o caracter separador decimal por "."
	if (sDigitoDecimalEntrada !=""){
		Numero = replace(Numero,sDigitoDecimalEntrada,"."); 
	}

	//Verifica se é um numero
	if (isNaN(parseFloat(Numero))) return false;

	//Retira zeros a esquerda e a direita desnecessários
	Numero = Numero - 0;

	//Converte o numero para string
	Numero =  Numero + "";

	//Verifica se ainda existe separador de decimal
	if (Numero.indexOf(".") == -1) sDigitoDecimalEntrada = "";

	//Verifica se existe digito decimal de entrada
	if (sDigitoDecimalEntrada != ""){
		//Separa as partes do número
		aNumero = Numero.split(".");
		//Verifica o tamanho das partes
		if (aNumero[0].length > iQtdInteiros || aNumero[1].length > iQtdDecimais)
			return false;
	//Senão verifica o tamanho do numero
	}else if (Numero.length > iQtdInteiros)
		return false;
		
	return true;

}

function fnValidaCEP(sCEP){

	var aCEP;
	
	sCEP = sCEP + "";
	aCEP = sCEP.split("-");
	
	if (sCEP.length != 9) return false;
	if (aCEP.length != 2) return false;
	if (aCEP[0].length != 5 || !isInteger(aCEP[0])) return false;
	if (aCEP[1].length != 3 || !isInteger(aCEP[1])) return false;
	
	return true;
}

// isAlphabetic (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if string s is English letters 
// (A .. Z, a..z) only.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.
//
// NOTE: Need i18n version to support European characters.
// This could be tricky due to different character
// sets and orderings for various languages and platforms.

function isAlphabetic (s)

{   var i;

    if (isEmpty(s)) 
       if (isAlphabetic.arguments.length == 1) return defaultEmptyOK;
       else return (isAlphabetic.arguments[1] == true);

    // Search through string's characters one by one
    // until we find a non-alphabetic character.
    // When we do, return false; if we don't, return true.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is letter.
        var c = s.charAt(i);

        if (!isLetter(c))
        return false;
    }

    // All characters are letters.
    return true;
}


// isAlphanumeric (STRING s [, BOOLEAN emptyOK])
// 
// Returns true if string s is English letters 
// (A .. Z, a..z) and numbers only.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.
//
// NOTE: Need i18n version to support European characters.
// This could be tricky due to different character
// sets and orderings for various languages and platforms.

function isAlphanumeric (s)

{   var i;

    if (isEmpty(s)) 
       if (isAlphanumeric.arguments.length == 1) return defaultEmptyOK;
       else return (isAlphanumeric.arguments[1] == true);

    // Search through string's characters one by one
    // until we find a non-alphanumeric character.
    // When we do, return false; if we don't, return true.

    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is number or letter.
        var c = s.charAt(i);

        if (! (isLetter(c) || isDigit(c) ) )
        return false;
    }

    // All characters are numbers or letters.
    return true;
}

function ltrim(s) {
	var i = 0;
    while ( (i < s.length) && charInString(s.charAt(i), " ") )
       i++;
    return s.substring(i, s.length);
}

function rtrim(s) {
	var i = s.length - 1;
    while ( (i > 0) && s.charAt(i) == " " )
       i--;
    return s.substring(0, (i==0)?s.length:++i)
}

function trim(s) {
	return ltrim(rtrim(s));
}


function mid(str, start, len)
/***
        IN: str - the string we are LEFTing
            start - our string's starting position (0 based!!)
            len - how many characters from start we want to get

        RETVAL: The substring from start to start+len
***/
{
        // Make sure start and len are within proper bounds
        if (start < 0 || len < 0) return "";

        var iEnd, iLen = String(str).length;
        if (start + len > iLen)
                iEnd = iLen;
        else
                iEnd = (start -1) + len;

        return String(str).substring(start -1,iEnd);
}


function len(str)
{  return String(str).length;  }


function reformat (s)

{   var arg;
    var sPos = 0;
    var resultString = "";

    for (var i = 1; i < reformat.arguments.length; i++) {
       arg = reformat.arguments[i];
       if (i % 2 == 1) resultString += arg;
       else {
           resultString += s.substring(sPos, sPos + arg);
           sPos += arg;
       }
    }
    return resultString;
}



function isIntegerInRange (s, a, b)
{   if (isEmpty(s)) 
       if (isIntegerInRange.arguments.length == 1) return defaultEmptyOK;
       else return (isIntegerInRange.arguments[1] == true);

    // Catch non-integer strings to avoid creating a NaN below,
    // which isn't available on JavaScript 1.0 for Windows.
    if (!isInteger(s, false)) return false;

    // Now, explicitly change the type to integer via parseInt
    // so that the comparison code below will work both on 
    // JavaScript 1.2 (which typechecks in equality comparisons)
    // and JavaScript 1.1 and before (which doesn't).
    var num = parseFloat (s);
    return ((num >= a) && (num <= b));
}

function isYear (s)
{   if (isEmpty(s)) 
       if (isYear.arguments.length == 1) return defaultEmptyOK;
       else return (isYear.arguments[1] == true);
    if (!isNonnegativeInteger(s)) return false;
    return ((s.length == 2) || (s.length == 4));
}

function isMonth (s)
{   if (isEmpty(s)) 
       if (isMonth.arguments.length == 1) return defaultEmptyOK;
       else return (isMonth.arguments[1] == true);
    return isIntegerInRange (s, 1, 12);
}

function isDay (s)
{   if (isEmpty(s)) 
       if (isDay.arguments.length == 1) return defaultEmptyOK;
       else return (isDay.arguments[1] == true);   
    return isIntegerInRange (s, 1, 31);
}

function daysInFebruary (year)
{   // February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (  ((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0) ) ) ? 29 : 28 );
}

function isDate (year, month, day)
{   // catch invalid years (not 2- or 4-digit) and invalid months and days.
    if (! (isYear(year, false) && isMonth(month, false) && isDay(day, false))) return false;

    // Explicitly change type to integer to make code work in both
    // JavaScript 1.1 and JavaScript 1.2.
    var intYear = parseInt(year);
    var intMonth = parseInt(month);
    var intDay = parseInt(day);

    // catch invalid days, except for February
    if (intDay > daysInMonth[intMonth]) return false; 

    if ((intMonth == 2) && (intDay > daysInFebruary(intYear))) return false;

    return true;
}


function isDateString(stringValue) {

	// this function is designed to mimic the "date" portion of the
	// VBScript IsDate() function, allowing dates to be validated
	// with JavaScript in browsers before you run into a problem
	// in ASP pages with date database columns or the VBScript
	// CDate() function; an exception is that string months
	// ("Jan," etc.) are not accepted
		
	// this function does not handle BC dates or dates past 12/31/9999
		
	// create a String object
	var theString = new String(trim(stringValue));
		
	// determine the delimiter character (must be "/" "-" or space)
	var delimiterCharacter;
	
	if ( theString.indexOf('/') > 0 )
		delimiterCharacter = '/';
	else
		if ( theString.indexOf('-') > 0 )
			delimiterCharacter = '-';
		else
			if ( theString.indexOf(' ') > 0 )
				delimiterCharacter = ' ';
			else
				return false;
					
	// split the string into an array of tokens
	var theTokens = theString.split(delimiterCharacter);
		
	// there must be either two or three tokens
	//if (theTokens.length < 2 || theTokens.length > 3 )
	if (theTokens.length != 3)
		return false;
		
	// convert the tokens to String objects, which will be needed later,
	// stripping a single leading 0
	var tokenIndex;
	for ( tokenIndex = 0; tokenIndex < theTokens.length; tokenIndex++ ) {
		theTokens[tokenIndex] = new String(theTokens[tokenIndex])			
		if ( theTokens[tokenIndex].charAt(0) == '0' )
			theTokens[tokenIndex] = theTokens[tokenIndex].substring(1, theTokens[tokenIndex].length);
	}

	// all of the tokens must be positive integers
	for ( tokenIndex = 0; tokenIndex < theTokens.length; tokenIndex++ ) {
		if ( ! isNonnegativeInteger(theTokens[tokenIndex]) )
			return false;
	}

	// we need to identify the year, month, and day tokens
	var numericValue;
	var yearTokenIndex = -1;
	var monthTokenIndex = -1;
	var dayTokenIndex = -1;
					
	for ( tokenIndex = 0; tokenIndex < theTokens.length; tokenIndex++ ) {
		// convert the value
		numericValue = parseInt(theTokens[tokenIndex], 10);
					
		if ( tokenIndex == 0 && numericValue <= 31 ) 
			dayTokenIndex = tokenIndex;
		if ( tokenIndex == 1 && numericValue <= 12 ) 
			monthTokenIndex = tokenIndex;
		if ( tokenIndex == 2 && (numericValue >= 1900 && numericValue <= 9999) ) 
			yearTokenIndex = tokenIndex;
	}	// end of for loop
		
	// evaluate, based on the number of tokens
	if ( theTokens.length == 2 ) {
			
		// two tokens can be either a month/year combination or a month/day
		// combination with the current year assumed; either way, we must have
		// a month
		if ( monthTokenIndex == -1 )
				
			// no month
			return false;
				
		// do we have a year?
		if ( ! (yearTokenIndex == -1) ) {
			
			// yes; month/year combination; must be okay
			return true;
		}
		else
				
			// no year; do we have a day?
			if ( ! (dayTokenIndex == -1) ) {
				
				// yes; month/day combination; get the current year
				var today = new Date();
				var currentYear = today.getYear();

				// make sure it's a valid date (we were testing days using
				// 31, and that might be too many for the month)
				return isDate(currentYear, theTokens[monthTokenIndex], theTokens[dayTokenIndex]);
			}
			else
				
				// we have neither a year nor a day
				return false;
	}
	else {
			
		// three tokens; we should have found tokens for year, month, and day
		if ( yearTokenIndex == -1 || monthTokenIndex == -1 || dayTokenIndex == -1 )
				
			// missing one or more
			return false;
		else
				
			// found all; however, VBScript can only handle the following sequences
			if ( monthTokenIndex == 0 ) {
				
				// must be m/d/y
				if ( dayTokenIndex != 1 || yearTokenIndex != 2)
					return false;
			}
			else
				if ( dayTokenIndex == 0 ) {
				
					// must be d/m/y
					if ( monthTokenIndex != 1 || yearTokenIndex != 2)
						return false;
				}
				else
					if ( yearTokenIndex == 0 ) {
				
						// must be y/m/d
						if ( monthTokenIndex != 1 || dayTokenIndex != 2)
							return false;
					}
					else
						
						// something is wrong
						return false;
				
			// make sure it's a valid date (we were testing days using a value
			// of 31, and that might be too many for the actual month)
			return isDate(theTokens[yearTokenIndex], theTokens[monthTokenIndex], theTokens[dayTokenIndex]);
	}
}

function isTimeString(sHoraMinSeg) {
var sHoraMinSegAux = new String(sHoraMinSeg);
var aHoraMinSegAux = sHoraMinSegAux.split(':');

	if (aHoraMinSegAux.length < 2 || aHoraMinSegAux.length > 3) {
		return false;
	}
	
	var sHora = new String(aHoraMinSegAux[0]);
	sHora = trim(sHora);
	if (!isIntegerInRange(sHora, 0, 23)) {
		return false;
	}
	
	var sMinuto = new String(aHoraMinSegAux[1]);
	sMinuto = trim(sMinuto);
	if (!isIntegerInRange(sMinuto, 0, 59)) {
		return false;
	}
	
	var sSegundo = new String(aHoraMinSegAux[2]);
	sSegundo = trim(sSegundo);
	if (!isIntegerInRange(sSegundo, 0, 59)) {
		return false;
	}
		
	return true;
}

function dateDiff(intervalo,data1,data2) {

	date1 = new Date();
	date2 = new Date();
	diff  = new Date();

	if (isDateString(data1)) { // Validates first date 
		data1 = formatDate (data1,"mm/dd/yyyy")
		date1 = new Date(data1);
	}
	else return false; // otherwise exits

	if (isDateString(data2)) { // Validates second date 
		data2 = formatDate (data2,"mm/dd/yyyy")
		date2 = new Date(data2);
	}
	else return false; // otherwise exits

	// sets difference date to difference of first date and second date
	timediff = date2.getTime() - date1.getTime();
	
	switch(intervalo){
		case "y" :
			return date2.getYear() - date1.getYear();
		case "m" :
			return (((date2.getYear() - date1.getYear()) * 12) + (date2.getMonth() - date1.getMonth()))
		case "w" :
			return Math.floor(timediff / (1000 * 60 * 60 * 24 * 7));
		case "d" :
			return Math.floor(timediff / (1000 * 60 * 60 * 24)); 
		case "h" :
			return Math.floor(timediff / (1000 * 60 * 60)); 
		case "n" :
			return Math.floor(timediff / (1000 * 60)); 
		case "s" :
			return Math.floor(timediff / 1000); 
		case "ms" :
			return timediff;
		default :
			return false;
	}		
}

function dateAdd(intervalo,numero,data1){

	date1 = new Date();

	if (isDateString(data1)) { // Validates first date 
		data1 = formatDate (data1,"mm/dd/yyyy")
		date1 = new Date(data1);
	}
	else return false;
	
	if (!isSignedInteger(numero)) return false;

	switch(intervalo){
		case "y" :
			var year = parseFloat(date1.getYear() + parseFloat(numero));
			return formatDate(date1.getDate() + "/" + parseFloat(date1.getMonth() + 1) + "/" + year,"dd/mm/yyyy")
		case "m" :
			date1.setMonth(date1.getMonth() + parseFloat(numero));
			var month = new String(parseFloat(date1.getMonth() + 1));
			return formatDate(date1.getDate() + "/" + month + "/" + date1.getYear(),"dd/mm/yyyy");
		case "d" :
			date1.setDate(date1.getDate() + parseFloat(numero));
			var day = new String(date1.getDate());
			return formatDate(day + "/" + parseFloat(date1.getMonth() + 1) + "/" +  date1.getYear(),"dd/mm/yyyy");
		default :
			return false;
	}		
}

function formatDate(data,formato){
	
	var arrData1;
	var dia;
	var mes;
	var ano;

	var sSubistitui;

	if (!isDateString(data)) return false;
	
	data = trim(data);
	data = replace(data,".","/");
	data = replace(data,"-","/");
	data = replace(data," ","/");
	
	arrData1 = data.split("/");
	try{
		dia = arrData1[0];
		mes = arrData1[1];
		ano = arrData1[2];

	}catch(Erro){
		return false;
	}

	sSubistitui = replace(formato, "dd", right("0"+dia,2))
	sSubistitui = replace(sSubistitui, "d", dia);
		
	sSubistitui = replace(sSubistitui, "mm", right("0"+mes,2))
	sSubistitui = replace(sSubistitui, "m", mes);

	sSubistitui = replace(sSubistitui, "yyyy", right("0000" + ano,4))
	return replace(sSubistitui, "yy", right(ano,2));

}

function today(){
	var data = new Date();
	return right("0" + data.getDate(),2) + "/" + right("0" + parseFloat(data.getMonth() + 1),2) + "/" + data.getYear();
}

function toTime() {
var sData = new Date();
	return right("000" + mid(sData, 11, 9), 9);
}

function string$(sCaracter,iTamanho){
	var sRetorno = '';
	for (var iContador=1;iContador<=iTamanho;iContador++){
		sRetorno = sRetorno + sCaracter;
	}
	return sRetorno;
}

function round(number,X) {
// rounds number to X decimal places, defaults to 2
    X = (!X ? 2 : X);
    return Math.round(number*Math.pow(10,X))/Math.pow(10,X);
}

function FormatNumber(Numero,sDigitoDecimalSaida,iCasasDecimais,bExibeMilhar){

	var sDigitosPermitidos = "-.-,";
	var sDigitoMilhar;
	var sSinal = "";
	var aNumeroSeparado;

	var sDigitoDecimalEntrada = "";
	var iPosVirgula = -1;
	var iPosPonto = -1;

	Numero = Numero + "";
	
	if (sDigitosPermitidos.indexOf(sDigitoDecimalSaida)== -1) return false;
	if (sDigitosPermitidos.indexOf(sDigitoDecimalEntrada)== -1) return false;
	if (Numero.indexOf(",") < Numero.indexOf(".") && Numero.indexOf(".") < Numero.lastIndexOf(",")) return "NaN";
	if (Numero.indexOf(".") < Numero.indexOf(",") && Numero.indexOf(",") < Numero.lastIndexOf(".")) return "NaN";
	if (iCasasDecimais < 0) return false;
	
	iPosVirgula = Numero.indexOf(",");
	iPosPonto = Numero.indexOf(".");
	if (iPosVirgula > iPosPonto && iPosPonto != -1){
		Numero = replace(Numero,".","")
		sDigitoDecimalEntrada = ",";
	}else if (iPosVirgula < iPosPonto && iPosVirgula != -1){
		Numero = replace(Numero,",","")
		sDigitoDecimalEntrada = ".";
	}else if (iPosVirgula > -1 && iPosPonto == -1){
		sDigitoDecimalEntrada = ",";
	}else if (iPosPonto > -1 && iPosVirgula == -1){
		sDigitoDecimalEntrada = ".";
	}else{
		sDigitoDecimalEntrada = "";
	}

	if (sDigitoDecimalEntrada != ""){
		Numero = replace(Numero,sDigitoDecimalEntrada,".");
	}

	if (sDigitoDecimalSaida == "."){
		sDigitoMilhar = ",";
	}else{
		sDigitoMilhar = ".";
	}
			
	if (isNaN(parseFloat(Numero))) return "NaN";
	
	if (left(Numero,1) == "-"){
		Numero = right(Numero,Numero.length - 1);
		sSinal = "-";
	}else
		sSinal = "";

	if (Numero.indexOf(".") == -1){
		if (iCasasDecimais != 0)
			Numero = Numero + sDigitoDecimalSaida + string$(0,iCasasDecimais);
	}else{
		var sDecimal = right(Numero,Numero.length - Numero.indexOf(".") - 1);
		if (sDecimal.length <= iCasasDecimais){
			Numero = Numero + string$(0,iCasasDecimais - sDecimal.length);
		}else{
			Numero = round(Numero,iCasasDecimais) + ""
		}
	}

	Numero = replace(Numero,".",sDigitoDecimalSaida);

	if (bExibeMilhar){

		aNumeroSeparado = Numero.split(sDigitoDecimalSaida);

		Numero = aNumeroSeparado[0];
		if (Numero.length > 3){
			aNumeroSeparado[0] = "";
			while (Numero.length > 0){
				aNumeroSeparado[0] = sDigitoMilhar + right(Numero,3) + aNumeroSeparado[0];
				Numero = left(Numero,Numero.length - 3);
			}
			aNumeroSeparado[0] = right(aNumeroSeparado[0],aNumeroSeparado[0].length - 1); 
		}

		if (aNumeroSeparado.length == 1)
			Numero = aNumeroSeparado[0];
		else
			Numero = aNumeroSeparado[0] + sDigitoDecimalSaida + aNumeroSeparado[1];
	}
	
	return sSinal + Numero;		
}


//no evento onkeyPress passar os parametros this, this.value
//Consiste a data na digitação
function putdata(Control,Value)
{
	var Caracteres="/0123456789";
   var Keyascii = event.keyCode;
	var sCaracter = String.fromCharCode(Keyascii);
	var strData;
	var rngSelecao = Control.createTextRange();
	var intPosicao = fnPosicaoText();
	var intSelecao
	
	
	if (Caracteres.indexOf(sCaracter)==-1){
		event.returnValue = 0;
		return;
	}
	
	if(sCaracter == "/"){
		if(intPosicao == 2 || intPosicao == 5){
			Control.value = mid(Value, 1, intPosicao) + "/" + mid(Value, intPosicao + 1, Value.length - intPosicao + 1);
			fnMudaPosicaoText(Control, Value.length - intPosicao);
		}
		event.returnValue = false;
		return;
	}
	
	if(fnSelecaoText(0) > 0){		
		if(fnSelecaoText(1) == "/"){			
			fnMudaPosicaoText(Control, Value.length - intPosicao);			
			event.returnValue = false;
			return;
		}
		intSelecao = fnSelecaoText(0);
		switch(intPosicao - intSelecao){			
			case 0:
				if(sCaracter > 3){
					event.returnValue = false;
					return;
				}
				break;
			case 1:
				if(mid(Value, 1, 1) == 3){					
					if(sCaracter > 1){
						event.returnValue = false;
						return;
					}					
				}
				break;				
			case 3:
				if(sCaracter >= 2){
					event.returnValue = false;
					return;	
				}
				break;				
			case 4:
				if(mid(Value, 4, 1) == 1){
					if(sCaracter > 2){
						event.returnValue = false;
						return;						
					}
				}
				break;				
		}
		
		if(fnPosicaoText() - fnSelecaoText(0) == 2 || fnPosicaoText() - fnSelecaoText(0) == 5){
				strData = mid(Value, 1, intPosicao - intSelecao + 1) + sCaracter + mid(Value, intPosicao - intSelecao + 3, Value.length);
				Control.value = strData;
				rngSelecao.moveStart('character', intPosicao - intSelecao + 2);
				rngSelecao.moveEnd('character', (Value.length - intPosicao) * -1);
				rngSelecao.select();
				if(fnSelecaoText(1) == "/"){
					fnMudaPosicaoText(Control, Value.length - intPosicao);
				}
		}else{			
			strData = mid(Value, 1, intPosicao - intSelecao) + sCaracter + mid(Value, intPosicao - intSelecao + 2, Value.length);
			Control.value = strData;
			rngSelecao.moveStart('character', intPosicao - intSelecao + 1);
			rngSelecao.moveEnd('character', (Value.length - intPosicao) * -1);
			rngSelecao.select();
			if(fnSelecaoText(1) == "/"){
				fnMudaPosicaoText(Control, Value.length - intPosicao);
			}
		}
		event.returnValue = false;
		return;
	}else{
		if(Value.length == 10){
			event.returnValue = false;
			return;
		}
		switch (fnPosicaoText()){
		
			case 2: //mes
				if(Value.length != 9){
					if (isDate('2000', sCaracter + '1', '01' )){
					   Control.value = mid(Value,1, 2) + "/" + sCaracter + mid(Value, 3 , Value.length - 2);
						event.returnValue = false;
						fnMudaPosicaoText(Control, Value.length - intPosicao);
						break;
					}else{
					   event.returnValue = false;
						break;
					}
				}
				event.returnValue = false;
				break;
			case 3: //mes
				if (isDate('2000', sCaracter + '1', '01' )){
				   Control.value = mid(Value,1, 3) + sCaracter + mid(Value,4, Value.length - 3);
					event.returnValue = false;
					fnMudaPosicaoText(Control, Value.length - intPosicao);
					break;
				}else{
				   event.returnValue = false;
					break;
				}
			case 4://mes
				intPosicao = fnPosicaoText();
				if (isDate('2000', mid(Value, 4, 1) + sCaracter, '01' )){
				   Control.value = mid(Value,1, 3) + mid(Value, 4, 1) + sCaracter + mid(Value,intPosicao + 1, Value.length - intPosicao);
					event.returnValue = false;
					fnMudaPosicaoText(Control, Value.length - intPosicao);
					break;
				}else{
					event.returnValue = false;
					break;
				}
			case 5:
				if(sCaracter < 2){
					event.returnValue = false;
					break;
				}			
				if(Value.length != 9){
					if (isDate(sCaracter + '000','01','01')){
					   Control.value = mid(Value,1, 5) + "/" + sCaracter + mid(Value, 6, Value.length - 5);
					   event.returnValue = false;
					   fnMudaPosicaoText(Control, Value.length - intPosicao);
						break;
					}else{
						event.returnValue = false;
						break;
					}
				}
				event.returnValue = false;
				break;				
			case 6:
				if(sCaracter < 2){
					event.returnValue = false;
					break;
				}
				if (isDate(sCaracter + '000','01','01')){
				   Control.value = mid(Value,1, 6) + sCaracter + mid(Value, 7, Value.length - 6);
				   event.returnValue = false;
				   fnMudaPosicaoText(Control, Value.length - intPosicao);
					break;
				}else{
					event.returnValue = false;
					break;
				}
		}
	}
}

function MascaraDataHora(Control, Value)
{
	var Caracteres="0123456789";
    var Keyascii = event.keyCode;

	if (Caracteres.indexOf(String.fromCharCode(Keyascii)) == -1){
		event.returnValue = 0;
		return;
	}

    switch (Value.length)
        {
        case 2:
            {
				if (isDate('2000', '01', Value)){
	                Control.value = Value + "/";
					event.returnValue = true;
			        break;
				}else{
				    event.returnValue = false;
					break;
				}
			}
        case 5:
            {
				if (isDate('2000', mid(Value, 4, 2), left(Value, 2))){
                    Control.value = Value + "/";
				    event.returnValue = true;
					break;
				}else{
					event.returnValue = false;
					break;
				}
			}
        case 9:
            {
				var sData = Value + String.fromCharCode(Keyascii);
				if (isDate(mid(sData, 7, 4), mid(sData ,4, 2), left(sData, 2))){
				    event.returnValue = false;
				    Control.value = sData + " - ";
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
            }
        case 13:
            {
				var sHora = String.fromCharCode(Keyascii);
				if (parseFloat(sHora) <= 2){
				    event.returnValue = true;
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
				   
            }
        case 14:
            {
				var sData = left(Control.value, 13)
				var sHora = right(Control.value, 1) + String.fromCharCode(Keyascii);
				if (parseFloat(sHora) <= 23){
				    event.returnValue = false;
				    Control.value = sData + sHora + ":";
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
				   
            }
        case 16:
            {
				var sData = left(Control.value, 13)
				var sHora = right(Control.value, 3) + String.fromCharCode(Keyascii);
				if (isTimeString(sHora + "0:00")){
				    event.returnValue = false;
				    Control.value = sData + sHora;
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
				   
            }
        case 17:
            {
				var sData = left(Control.value, 13)
				var sHora = right(Control.value, 4) + String.fromCharCode(Keyascii);
				if (isTimeString(sHora + ":00")){
				    event.returnValue = false;
				    Control.value = sData + sHora + ":";
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
				   
            }
        case 19:
            {
				var sData = left(Control.value, 13)
				var sHora = right(Control.value, 6) + String.fromCharCode(Keyascii);
				if (isTimeString(sHora + "0")){
				    event.returnValue = false;
				    Control.value = sData + sHora;
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
				   
            }
        case 20:
            {
				var sData = left(Control.value, 13)
				var sHora = right(Control.value, 7) + String.fromCharCode(Keyascii);
				if (isTimeString(sHora)){
				    event.returnValue = false;
				    Control.value = sData + sHora;
				    break;
				}else{
				    Control.value = Value;
				    event.returnValue = false;
				    break;
                }
				   
            }
		case 23:
			event.returnValue = false;
	}
}

//no evento onKeyPress passar os parametros this, this.value
//Consiste a hora na digitação
function puthora(Control,Value)
{
	var Caracteres="0123456789";
    var Keyascii = event.keyCode;
                                
	if (Caracteres.indexOf(String.fromCharCode(Keyascii))==-1){
		event.returnValue = 0;
		return;
	}

	if(Value.length < 5){
		switch (Value.length)
		    {
		    case 1:
				{
					if (Value >= 0 && Value <= 2){
						event.returnValue = true;
				        break;
					}else{
					    event.returnValue = false;
						break;
					}
				}
		    case 2:
		        {	
					if (Value.substring(1,0) == 1 || Value.substring(1,0) == 0){
						if (Value.substring(2,1) >= 0 && Value.substring(2,1) <= 9){
						    Control.value = Value + ":";
							event.returnValue = true;
						    break;
						}else{
						    event.returnValue = false;
							break;
						}
					}
					if (Value.substring(1,0) == 2){
						if (Value.substring(2,1) >= 0 && Value.substring(2,1) <= 4){
						    Control.value = Value + ":";
							event.returnValue = true;
						    break;
						}else{
						    event.returnValue = false;
							break;
						}
					}
				}
			case 4:
		        {
					if (Value.substring(4,3) >= 0 && Value.substring(4,3) <= 5){
					    event.returnValue = true;
						break;
					}else{
						event.returnValue = false;
						break;
					}
				}
			case 5:
		        {
					if (Value.substring(5,4) >= 0 && Value.substring(5,4) <= 9){
					    event.returnValue = true;
						break;
					}else{
						event.returnValue = false;
						break;
					}
				}
		}
	}else{
		event.returnValue = false;
	}
}


function fnConsisteHora(intHora){
	var intContador;	
	var strCaracter;
	for(intContador = 1; intContador <= 8; intContador++){
		strCaracter = mid(intHora, intContador, 1);
		switch(intContador){
				case 1:
					if(strCaracter > 2 || strCaracter < 0){
						return false;
					}
					break;
				case 2:
					if(mid(intHora, 1, 1)==2){
						if(strCaracter > 3 || strCaracter < 0){
							return false;
						}											
					}
					break;
				case 3:				
					if(strCaracter != ":"){
						return false;
					}
					break;
				case 4:
					if(strCaracter > 5 || strCaracter < 0){
						return false;
					}
					break;
				case 6:				
					if(strCaracter != ":"){
						return false;
					}
					break;
				case 7:
					if(strCaracter > 5 || strCaracter < 0){
						return false;
					}
					break;					
		}		
	}
	return true;	
}

//no evento onKeyPress passar os parametros this, this.value
//Consiste a hora e segundos na digitação

function puthorasegundo(Objeto,Value){
	
	var Caracteres=":0123456789";
	var Keyascii = event.keyCode;
	var sCaracter = String.fromCharCode(Keyascii);	
	var intHora = Objeto.value;
	var intPosicao = fnPosicaoText();
	var strFormato = "00:00:00";
	var intHora;
	var intHoraTamanho = intHora.length;
	var bolHoraValida;
	var rngSelecao = Objeto.createTextRange();
	var strHora;
	intSelecao = fnSelecaoText(0);
	
	if (Caracteres.indexOf(String.fromCharCode(Keyascii))==-1){
		event.returnValue = 0;
		return;
	}
	if(sCaracter == ":"){
		if(intPosicao == 2 || intPosicao == 5){
			Objeto.value = mid(Value, 1, intPosicao) + ":" + mid(Value, intPosicao + 1, Value.length - intPosicao + 1);
			fnMudaPosicaoText(Objeto, Value.length - intPosicao);
		}
		event.returnValue = false;
		return;
	}	
	
	if(fnSelecaoText(0) > 0){
		if(fnPosicaoText() - fnSelecaoText(0) == 2 || fnPosicaoText() - fnSelecaoText(0) == 5){
			strHora = mid(Value, 1, intPosicao - intSelecao + 1) + sCaracter + mid(Value, intPosicao - intSelecao + 3, Value.length);
			bolHoraValida = fnConsisteHora(strHora);
			event.returnValue = false;
			if(bolHoraValida){
				Objeto.value = strHora;
				rngSelecao.moveStart('character', intPosicao - intSelecao + 2);
				rngSelecao.moveEnd('character', (Value.length - intPosicao) * -1);
				rngSelecao.select();
				if(fnSelecaoText(1) == ":"){
					fnMudaPosicaoText(Objeto, Value.length - intPosicao);
				}				
			}
		}else{			
			strHora = mid(Value, 1, intPosicao - intSelecao) + sCaracter + mid(Value, intPosicao - intSelecao + 2, Value.length);			
			bolHoraValida = fnConsisteHora(strHora);
			event.returnValue = false;
			if(bolHoraValida){
				Objeto.value = strHora;
				rngSelecao.moveStart('character', intPosicao - intSelecao + 1);
				rngSelecao.moveEnd('character', (Value.length - intPosicao) * -1);
				rngSelecao.select();
				if(fnSelecaoText(1) == ":"){
					fnMudaPosicaoText(Objeto, Value.length - intPosicao);
				}				
			}
		}
		return;			
	}else{
		if(intHoraTamanho == 8){
			event.returnValue = false;
			return;
		}
		if(intPosicao == intHoraTamanho){
			if(intPosicao != 2 && intPosicao != 5){
				bolHoraValida = fnConsisteHora(intHora + sCaracter + mid(strFormato, intPosicao + 2, 7 - intPosicao));			
				if(bolHoraValida){
					event.returnValue = true;
					return;
				}else{
					event.returnValue = false;
					return;
				}
			}
			if(intPosicao == 2 || intPosicao == 5){
				bolHoraValida = fnConsisteHora(intHora + ":" + sCaracter + mid(strFormato, intPosicao + 3, 6 - intPosicao));
				if(bolHoraValida){
					Objeto.value = intHora + ":" + sCaracter;
					event.returnValue = false;
					return;
				}else{
					event.returnValue = false;
					return;
				}
			}
		}else{
			
			if(intPosicao == 0){
				intHora = sCaracter + mid(intHora, 1, intHora.length - intPosicao);
			}else{
				if(intPosicao == 2 || intPosicao == 5){				
					intHora = left(intHora, intPosicao) + ":" + sCaracter + mid(intHora, intPosicao + 1, intHora.length - intPosicao);
				}else{
					intHora = left(intHora, intPosicao) + sCaracter + mid(intHora, intPosicao + 1, intHora.length - intPosicao);				
				}
			}
			bolHoraValida = fnConsisteHora(intHora + mid(intHora, fnPosicaoText() + 1, 8 - intHoraTamanho));
			if(bolHoraValida){
				event.returnValue = false;
				Objeto.value = intHora;
			}else{
				event.returnValue = false;	
			}
			fnMudaPosicaoText(Objeto, Value.length - intPosicao);
			return;
		}
	}
}		

function MsascaraCEP (objeto){

	var keypress = event.keyCode; 
	var campo = eval (objeto);

	var caracteres = '01234567890';
	var separacoes = 1;
	var separacao1 = '-';
	var conjuntos = 2;
	var conjunto1 = 5;
	var conjunto2 = 3;

	if ((caracteres.indexOf(String.fromCharCode (keypress))!=-1) && campo.value.length < 
	(conjunto1 + conjunto2 + 1)){
		if (campo.value.length == conjunto1) 
		   campo.value = campo.value + separacao1;
		}
	else 
		event.returnValue = false;
}

function fnMascaraInteiro(objeto){
	var keypress = event.keyCode; 
	var campo = eval (objeto);

	var sCaracteres = '0123456789';

	if (sCaracteres.indexOf(String.fromCharCode(keypress))!=-1){
		event.returnValue = true;
    }else 
		event.returnValue = false;
}

function fnMascaraValor(Objeto,iNumDecimais){
	var sCaracteres = "-0123456789,";
	var intNumero = Objeto.value;
	var intInteiro;
	var intDecimal;
	var intContador;
	var intMultiplo = 0;
	var intNovoInteiro = "";
	var intNegativo = 0;
	var intPosicao;
	var intTamOriginal;
	var sCaracter = String.fromCharCode(event.keyCode);
	var intParteEsq;
	var intParteDir;
	var intPosAtual;
	
	if (sCaracteres.indexOf(sCaracter)==-1){
		event.returnValue = false;
		return;
	}
	if(sCaracter == ","){
		if (intNumero.indexOf(",") != -1){
			event.returnValue = false;
			return;
		}
	}	
	if(event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 16 || event.keyCode == 36 || event.keyCode == 35){
		event.returnValue = false;
		return;
	}

	if(fnSelecaoText(0) > 0){
		intPosAtual = fnPosicaoText() - fnSelecaoText(0);
		intNumero = mid(intNumero, 1, fnPosicaoText() - fnSelecaoText(0)) + sCaracter + mid(intNumero,fnPosicaoText() + 1, intNumero.length - fnPosicaoText());						
	}else{
		intPosAtual = fnPosicaoText();
		intNumero = mid(intNumero,1, fnPosicaoText()) + sCaracter + mid(intNumero,fnPosicaoText() + 1, intNumero.length - fnPosicaoText());
	}
	if(intNumero.indexOf("-") >= 0){
		intNumero = replace(intNumero, "-", "");		
		intTamOriginal = intNumero.length - 1; 
		if(Objeto.value.indexOf("-") == -1){
			intNegativo = 1;
		}else{
			intNegativo = 0;
		}
	}else{
		intNegativo = 0;	
		intTamOriginal = intNumero.length;
	}
	
	if(intNumero.length == 0){
		intTamOriginal = 3;
	}
	intPosicao = intTamOriginal - intPosAtual - 1;
	if(sCaracter == ","){
		Objeto.value = intNumero;
		fnMudaPosicaoText(Objeto, intPosicao)
		event.returnValue = false;
		return;
	}
	intNumero = replace(intNumero, ".", "");
	intNumero = replace(intNumero, ",", "");

	
	if (intNumero.length <= Objeto.maxLength - 1 || left(intNumero, 1)=="0"){
		if(iNumDecimais != 0){
			if (intNumero.length <= iNumDecimais) 
				 intNumero = "0," + string$(0, iNumDecimais - intNumero.length) + intNumero;
			else{
				if (left(intNumero, iNumDecimais)==string$(0,iNumDecimais)){					
					if (iNumDecimais == 1)
						intNumero = mid(intNumero,2,1) + "," + right(intNumero, iNumDecimais);
					else
						intNumero = "0," + right(intNumero, iNumDecimais);
				}else if (left(intNumero, 1)=="0")
					intNumero = mid(intNumero,2,1) + "," + right(intNumero, iNumDecimais);
				else
					intNumero = left(intNumero, intNumero.length - iNumDecimais) + "," + right(intNumero, iNumDecimais);
			}
		}
		
		intNumero = FormatNumber(intNumero,",",iNumDecimais,true);
		if (intNegativo == 1){
			Objeto.value = "-" + intNumero;
		}else{
			Objeto.value = intNumero;
		}
		fnMudaPosicaoText(Objeto, intPosicao)
		event.returnValue = false;
		return;
	}
}

function fnReformataValor(Objeto, iNumDecimais){	
	var intNumero = replace(replace(Objeto.value, ".", ""), " ", "");
	var intPosicao = intNumero.indexOf(",");	
	var TamDecimais;
	
	if(intNumero != ""){
		if(intPosicao == -1){
			TamDecimais = 0;
		}else{
			TamDecimais = intNumero.length - intPosicao - 1;
		}
		Objeto.value = FormatNumber(intNumero, ",",iNumDecimais,true);
		
		/*
		break;		
		
		switch(TamDecimais){

			case 0:			
				intNumero = replace(intNumero, ",", "") + "," + string$("0", iNumDecimais);
				Objeto.value = FormatNumber(intNumero ,",",iNumDecimais,true);					
				break;
			case 1:			
				intNumero = intNumero;
				Objeto.value = FormatNumber(intNumero,",",iNumDecimais,true);				
				break;

			default:
				Objeto.value = FormatNumber(intNumero,",",iNumDecimais,true) + string$("0", iNumDecimais);
				break;

		}
				*/
	}		
}

function fnSelecaoText(flgTipo){
	var rngSelecao = document.selection.createRange();
	if(flgTipo==0){
		return rngSelecao.text.length;
	}else{
		return rngSelecao.text;
	}
}

function fnPosicaoText(){
	
	var rngSelecao = document.selection.createRange();
	
	rngSelecao.moveStart('textedit', -1);		
	return rngSelecao.text.length;
}
function fnMudaPosicaoText(Objeto, Posicao){
	var rngSelecao = Objeto.createTextRange();
	rngSelecao.moveStart('character', 1000);
	rngSelecao.moveEnd('character', Posicao * -1);
	rngSelecao.select();
}

/* FUNCTIONS TO NOTIFY USER OF INPUT REQUIREMENTS OR MISTAKES. */


// Display prompt string s in status bar.

function prompt (s)
{   window.status = s
}


// Display data entry prompt string s in status bar.

function promptEntry (s)
{   window.status = pEntryPrompt + s
}


// Notify user that required field theField is empty.
// String s describes expected contents of theField.value.
// Put focus in theField and return false.

function warnEmpty (theField, s)
{   theField.focus()
    alert(mPrefix + s + mSuffix)
    return false
}


// Notify user that contents of field theField are invalid.
// String s describes expected contents of theField.value.
// Put select theField, pu focus in it, and return false.

function warnInvalid (theField, s)
{   theField.focus()
    theField.select()
    alert(s)
    return false
}




/* FUNCTIONS TO INTERACTIVELY CHECK VARIOUS FIELDS. */

// checkString (TEXTFIELD theField, STRING s, [, BOOLEAN emptyOK==false])
//
// Check that string theField.value is not all whitespace.
//
// For explanation of optional argument emptyOK,
// see comments of function isInteger.

function checkString (theField, s, emptyOK)
{   // Next line is needed on NN3 to avoid "undefined is not a number" error
    // in equality comparison below.
    if (checkString.arguments.length == 2) emptyOK = defaultEmptyOK;
    if ((emptyOK == true) && (isEmpty(theField.value))) return true;
    if (isWhitespace(theField.value)) 
       return warnEmpty (theField, s);
    else return true;
}



// Check that string theField.value is a valid Year.
function checkYear (theField, emptyOK)
{   if (checkYear.arguments.length == 1) emptyOK = defaultEmptyOK;
    if ((emptyOK == true) && (isEmpty(theField.value))) return true;
    if (!isYear(theField.value, false)) 
       return warnInvalid (theField, iYear);
    else return true;
}


// Check that string theField.value is a valid Month.
function checkMonth (theField, emptyOK)
{   if (checkMonth.arguments.length == 1) emptyOK = defaultEmptyOK;
    if ((emptyOK == true) && (isEmpty(theField.value))) return true;
    if (!isMonth(theField.value, false)) 
       return warnInvalid (theField, iMonth);
    else return true;
}


// Check that string theField.value is a valid Day.
function checkDay (theField, emptyOK)
{   if (checkDay.arguments.length == 1) emptyOK = defaultEmptyOK;
    if ((emptyOK == true) && (isEmpty(theField.value))) return true;
    if (!isDay(theField.value, false)) 
       return warnInvalid (theField, iDay);
    else return true;
}



// checkDate (yearField, monthField, dayField, STRING labelString [, OKtoOmitDay==false])
function checkDate (yearField, monthField, dayField, labelString, OKtoOmitDay)
{   // Next line is needed on NN3 to avoid "undefined is not a number" error
    // in equality comparison below.
    if (checkDate.arguments.length == 4) OKtoOmitDay = false;
    if (!isYear(yearField.value)) return warnInvalid (yearField, iYear);
    if (!isMonth(monthField.value)) return warnInvalid (monthField, iMonth);
    if ( (OKtoOmitDay == true) && isEmpty(dayField.value) ) return true;
    else if (!isDay(dayField.value)) 
       return warnInvalid (dayField, iDay);
    if (isDate (yearField.value, monthField.value, dayField.value))
       return true;
    alert (iDatePrefix + labelString + iDateSuffix)
    return false
}


// Get checked value from radio button.
function getRadioButtonValue (radio)
{   for (var i = 0; i < radio.length; i++)
    {   if (radio[i].checked) { break }
    }
    return radio[i].value
}

// Carrega índices para o próximo controle e controle anterior
function InicializarIndices()
{
	if (document.CargaInicial==null)
	{
		document.CargaInicial=false;		// Seta para só fazer uma vez por documento
		var ctrlAnterior=null;
		var IndAnt=0;
		for ( var i=0; i<document.forms[0].elements.length;i++)
		{
			var e=document.forms[0].elements[i];
			if ( e.type!="hidden" && e.type!="image" )		
			{
				if ( ctrlAnterior != null )
					ctrlAnterior.IndicePosterior=i;
				ctrlAnterior=e;
				e.Indice=i;
				e.IndiceAnterior=IndAnt;
			}
		}
		//if ( ctrlAnterior!=null )
		//{
		//	ctrlAnterior.IndicePosterior=i-1;
		//}
	}
}

// Colocar o foco em determinado campo
function SetarFoco ( ind )
	{
	InicializarIndices();
	if ( isNaN(ind) && document.forms[0].elements[ind].type!="hidden" )
		document.forms[0].elements[ind].focus();
	else
		for (;ind<document.forms[0].elements.length;ind++)
			if ( document.forms[0].elements[ind].type!="hidden" )
				break;
		if ( ind<=document.forms[0].elements.length )
			document.forms[0].elements[ind].focus();
	}

// Limpar o conteúdo do(s) campo(s)
function LimparCampo ( ind )
	// Para -1, limpa todos os elementos
	{
	if (isNaN(ind))			// Limpa pelo nome
		document.forms[0].elements[ind].value="";
	else if (ind != -1 )	// Limpa o elemento "ind" ( só considera "text" e "password" )
		for ( var i=ind; i < document.forms[0].elements.length;i++ )
			if ( document.forms[0].elements[i].type=="text" || document.forms[0].elements[i].type=="password")		// Só limpa campo "text"
				{
				document.forms[0].elements[i].value="";
				break;
				}
	else					// Limpa todos os elementos "text" e "password"
		for ( var i=0; i < document.forms[0].elements.length; i++ )
			if ( document.forms[0].elements[i].type=="text" || document.forms[0].elements[i].type=="password" )
				document.forms[0].elements[i].value="";
		
	}

// Verificar qual navegador
function QualNavegador() 
{
	var s = navigator.appName;
	if ( s == "Microsoft Internet Explorer" )
		return "IE";
	else if ( s == "Netscape" )
		return "NE";
	else
		return "";
}

// Verificar qual a versão do navegador
function QualVersao()
{
	var s = navigator.appVersion;
	if ( QualNavegador() == "IE" )
	{
		var i = s.search("MSIE");
		s=s.substring(i+5);
		i=s.search(".");
		return parseInt(s.substring(0,i+1));
	}
	else if ( QualNavegador() == "NE" )
		return parseInt(s.substring(0,1));
	else
		return 0;
}


// Setar o evento
function SetarEvento(ctrl, Tam, Tipo, AutoSkip )
{
	// Filtra navegadores conhecidos
	var s = QualNavegador();
	if ( s.length==0 )
		return;
	if ( s=="IE" && QualVersao()>5 )
		return;
	if ( s=="NE" && QualVersao()>4 )
		return;

	if (ctrl.onkeypress==null)
	{
		if (AutoSkip==null)
			AutoSkip=true;
		if (Tipo!=null)
			Tipo.toUpperCase();
		ctrl.Tam=Tam;
		ctrl.Tipo=Tipo;
		ctrl.AutoSkip=true;
		ctrl.Saltar=false;
		InicializarIndices();
		ctrl.onkeypress=ValidarTecla;
		if (QualNavegador()=="IE" && QualVersao()==5)
			ctrl.onkeyup=SaltarCampo;
	}
}

function SaltarCampo(ctrl)
{
	if (ctrl==null)
		ctrl=this;
	if ( ctrl.AutoSkip && ctrl.Saltar)
		if (ctrl.Saltar)
		{
			ctrl.Saltar=false;
			if ( ctrl.IndicePosterior != null )
				SetarFoco(ctrl.IndicePosterior);
		}
}

// Fazer o salto de campo
function ValidarTecla (evnt)
{
	var tk;
    var c;
	// Recebe a tela pressionada
	tk = ( (QualNavegador()=="IE") ? event.keyCode : evnt.which);
    c=String.fromCharCode(tk);
	c=c.toUpperCase();
	
	// -- Este trecho faz com que o <Enter> tenha a função de <Tab>, mas acho inviável, pois não é possível
	//       colocar o foco em campos do Tipo "image", e, neste caso, nunca seria possível fazer a submissão
	//       do formulário
	// if ( tk == 13 )
	// {
	//	this.Saltar=true;
	//	SaltarCampo(this);
	//	return false;
	// }
	
	// Só aceita teclas alfanuméricas. Não aceita teclas de controle
    if ( tk == 59)
		return false;
    if ( tk == 39 )
		return false;
	if ( tk == 34 )
		return false
    if ( tk < 32 )
		return true;
	if ( tk > 127 )
		return false;
	switch ( this.Tipo )
	{
	case "D":
		if ( c<"0" || c>"9" )
			return false;
		break;
	case "N":
		
		if ( (c<"0" || c>"9") && (c!=",") )
			return false;
		if ( (c==",") && ((this.value.search(",")>-1) || (this.value.length==0)) )
			return false;
		if ( (c==",") && (this.value.length==0) )
			return false;
		break;
	case "C":
		if ( c<"A" || c>"Z" )
			return false;
		break;
	case "E":
		if ( tk == 8)
			return false;
		break;
	default:
		break;
	}

	this.Saltar=(this.value.length==this.Tam-1);
	if ( ((QualNavegador()=="IE") && QualVersao()<5) || (QualNavegador()!="IE") )
		SaltarCampo(this);

	return true;
}


// Rotina : Validação de CGC/CNPJ
// Retorno: Retorna TRUE se o CGC/CNPJ for válido e FALSE caso contrário. 
//
function fnValidaCNPJ(strCNPJ) 
{ 
       if (strCNPJ == ""){ 
          return false; 
       } 
       // REMOVER
       //if (strCNPJ == "00000000000000"){ 
       //   return false; 
       //} 
		        
       var strDV = strCNPJ.substr(12, 2), 
	                intSoma, 
	                intDigito = 0, 
	                strControle = "", 
	                strMultiplicador = "543298765432"; 
	                
		strCNPJ = strCNPJ.substr(0, 12); 
		   	         
	   for(var j = 1; j <= 2; j++) 
	   { 
	       intSoma = 0; 
	       for(var i = 0; i <= 11; i++) 
	       { 
	           intSoma += (parseInt(strCNPJ.substr(i, 1), 10) * parseInt(strMultiplicador.substr(i, 1), 10))

	       } 
           if(j == 2){ intSoma += (2 * intDigito) } 
           intDigito = (intSoma * 10) % 11; 
           if(intDigito == 10){intDigito = 0} 
           strControle += intDigito.toString(); 
           strMultiplicador = "654329876543"; 
      } 
      return(strControle == strDV); 
} 

function fnValidaCPF(sCPF){
var frase="1234567890-.";
var fcerta=true;

  for (i=0;i<sCPF.length;i++)
	 fcerta&=frase.indexOf(sCPF.charAt(i))!=-1;

  //var mascara=/\d{9,9}+[-]+\d{2,2}/;
  if (!fcerta){
return false;
  }
  else{
    var ls_num_cpf= replace(sCPF, ".", "");
    ls_num_cpf= replace(ls_num_cpf, "-", "");
  
    //Existem casos que o CPF tem um ou menos dígitos
    //nestes casos são adicionados um zeros a esquerda
    if (parseInt(ls_num_cpf.length)<11)
	  ls_num_cpf += string$("0",11 - ls_num_cpf.length); 
     
    //Calcula o primeiro digito de ls_num_cpf
    var li_conta1=0;
    for(i=1;i<=9;i++)
      li_conta1+=parseInt(ls_num_cpf.charAt(i-1))*(11-i);
	
    var li_conta2 = 11 - (li_conta1 % 11);
    if (li_conta2>9)
      li_conta2=0;

    if (li_conta2 != ls_num_cpf.charAt(ls_num_cpf.length-2)){
return false;
    }
 
    //Calcula o segundo digito de ls_num_cpf
    var li_conta1=0;
    for(i=1;i<=9;i++)
      li_conta1+=parseInt(ls_num_cpf.charAt(i))*(11-i);
	
    var li_conta2 = 11 - (li_conta1 % 11);
    if (li_conta2 > 9)
     li_conta2 = 0;

    if (li_conta2 == ls_num_cpf.charAt(ls_num_cpf.length-1)){
      confirm("Deseja continuar?");
    //return true;
    }
 }
return false;
}

function fnMascaraCNPJCPF(SCPFCNPJ)
{
//	SCPFCNPJ = eval (SCPFCNPJ);
	valor = SCPFCNPJ.value;
//	SCPFCNPJ.SCPFCNPJ = valor;
	
//	valor = right("00000000000000" + valor,14);

	if (valor.length == 10)
	{
		mask=valor.substring(0,3)+"."+valor.substring(3,6)+"."+valor.substring(6,9)+"-"+valor.substring(9,11);
		SCPFCNPJ.value = mask;
	}
	if (valor.length == 17)
	{
		valor = replace(SCPFCNPJ.value,".","");
		mask=valor.substring(0,2)+"."+valor.substring(2,5)+"."+valor.substring(5,8)+"/"+valor.substring(8,12)+"-"+valor.substring(12,14);
		SCPFCNPJ.value = mask;
	}
	
}
	
function fnTiraMascaraCNPJCPF(SCPFCNPJ)
{
	valor = SCPFCNPJ.value;

	if (valor.length == 14)
	{
		mask=valor.substring(0,3)+valor.substring(4,7)+valor.substring(8,11)+valor.substring(12,14);
		SCPFCNPJ.value=mask
	}
	if (valor.length == 18)
	{
		mask=valor.substring(0,2)+valor.substring(3,6)+valor.substring(7,10)+valor.substring(11,15)+valor.substring(16,18);
		SCPFCNPJ.value=mask;
	}
}

function ComparaDatas(pData1, pData2) {
// Faz a comparação entre duas datas
// Entrada: Data1 , Data2
// Saída:   0 - Data1 maior
//          1 - Data2 maior
//          2 - Datas iguais

var dia1		= left(pData1, 2);
var mes1		= left(right(pData1, 7), 2);
var ano1		= right(pData1, 4);
var dData1	= parseInt(ano1 + mes1 + dia1);

var dia2		= left(pData2, 2);
var mes2		= left(right(pData2, 7), 2);
var ano2		= right(pData2, 4);	
var dData2	= parseInt(ano2 + mes2 + dia2);

	if ( dData1 > dData2 ) {
		return 0;
	}
	if ( dData1 < dData2 ) {
		return 1;
	}
	if ( dData1 == dData2) {
		return 2;	
	}	
	return false;
}

function IIf(sCondicao, sTrue, sFalse) {
	if(sCondicao) {
		return sTrue;
	}else{
		return sFalse;
	}
}

function fnPreencheDataHora(oTextBox, sValor, iTipoHora) {
// iTipoHora = 0 --> '00:00:00'
// iTipoHora = 1 --> Hora Atual "toTime()"
// iTipoHora = 2 --> '23:59:59'
	var iTamanho = len(sValor);
	if(iTipoHora == 0){
		var sData = today() + ' - 00:00:00';
	}else if(iTipoHora == 1){
		var sData = today() + ' - ' + toTime();
	}else{
		var sData = today() + ' - 23:59:59';
	}
	oTextBox.value = trim(sValor) + right(sData, 21 - iTamanho);
}

function fnVerificaIniFim(objIni, objFim, lngTamanho){
	var strAuxi;
	var strAuxf;
		strAuxi  = eval('frmLista.' + objIni + '.value');
		strAuxf  = eval('frmLista.' + objFim + '.value');
		
		if(strAuxi.length != 0 || strAuxf.length != 0){	
			if(strAuxf.length == 0){
				if(strAuxi.indexOf('*') < 0){
					if(strAuxi.length != lngTamanho){
						alert("Preencha o campo completo ou Utilize o '*'.");
						eval('frmLista.' + objIni + '.focus()');
						eval('frmLista.' + objIni + '.select()');
						return false;
					}
				}
			}else{
				if(strAuxi.length != lngTamanho){
					alert('Preencha o campo completo');
					eval('frmLista.' + objIni + '.focus()');
					eval('frmLista.' + objIni + '.select()');
					return false;
				}else{								
					if(strAuxf.length != lngTamanho){
						alert('Preencha o campo completo');
						eval('frmLista.' + objFim + '.focus()');
						eval('frmLista.' + objFim + '.select()');		
						return false;
					}
				}
			}
		}
		return true;
}

function fnTrataFocus(oCampo1, oCampo2){

	if (oCampo1.style.backgroundColor=='#dcdcdc'){
		oCampo2.focus();
		if(oCampo2.type!='select-one'){
			oCampo2.select();
		}
	}else{
		oCampo1.focus();
		if(oCampo1.type!='select-one'){
			oCampo1.select();
		}
	}
}

//Para utilizar com o CustomValidator
function ConfirmaAcao(sender, args) 
{ 
	args.IsValid = confirm("Deseja continuar?")
} 

//no evento onKeyPress passar os parametros this, this.value
//Consiste a hora na digitação
function putcep(Control,Value)
{
	var Caracteres="0123456789";
    var Keyascii = event.keyCode;
                                
	if (Caracteres.indexOf(String.fromCharCode(Keyascii))==-1)
	{
		event.returnValue = 0;
		return;
	}

	if(Value.length <= 8)
			{
				switch (Value.length)
					{
					case 5:
						{
						Control.value = Value + "-";
						}
							

					}
			}

}
function confirma(pMsg)
{
confirm(pMsg);
}


function checkIt(string)
{
	place = detect.indexOf(string) + 1;
	thestring = string;
	return place;
}

//-->


