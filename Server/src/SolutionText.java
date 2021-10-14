//A class to handle the text fields for the solution cards
public enum SolutionText {
    A("Whole pack of jellybeans up my arse"),
    B("A poopoo"),
    C("Midgets riding a donkey"),
    D("Eating horse poop"),
    E("Mad cuz bad"),
    F("Donald Trump"),
    G("Dead parents"),
    H("People who like James Corden"),
    I("A donkey"),
    J("The crippling fear that a duck is watching you"),
    K("The finale of Game of Thrones"),
    L("Walt Disneys frozen head"),
    M("A raccoon in the trash"),
    N("Goat milk"),
    O("A dominatrix"),
    P("Semen"),
    Q("Porn addiction"),
    R("Bees?"),
    S("69 (nice)"),
    T("Dancing queen"),
    U("Big Time Rush"),
    V("Magnum condoms"),
    W("A crossword you can't solve"),
    X("Mom calling during sex"),
    Y("Saturday Night Live"),
    Z("Pogo the Clown"),
    AA("White people"),
    AB("Black people"),
    AC("Jennifer Lopez's booty"),
    AD("The offside rule"),
    AE("Karens"),
    AF("Pickles in Koolaid"),
    AG("Getting drunk with strangers"),
    AH("Having a deep conversation with a stranger"),
    AI("Poseidon's kiss"),
    AJ("The Greek Pantheon"),
    AK("Getting kicked so hard in the nuts, you lose your sense of vison"),
    AL("Communism"),
    AM("Proud nerds"),
    AN("Regretting a tattoo"),
    AO("Medialogy"),
    AP("K-pop"),
    AQ("Psychotic murder spree"),
    AR("My celebrity crush"),
    AS("Getting horny by 2D chicks"),
    AT("The second coming of Christ"),
    AU("Farting and a little bit of poop comes out"),
    AV("The casting couch"),
    AW("The complete Friends box-set"),
    AX("Niel Patrick Harris"),
    AY("An Oedipus complex"),
    AZ("Beastiality"),
    AAA("IM BATMAN!"),
    AAB("Jeff Bezos penis rocket"),
    AAC("Diversity"),
    AAD("Asians"),
    AAE("Pamela Anderson's... assets"),
    AAF("The Nirvana baby"),
    AAG("Michelle Obama"),
    AAH("Killing it on the dancefloor"),
    AAI("Seeing babies being electrocuted"),
    AAJ("Being born"),
    AAK("Buttsex"),
    AAL("The moon landing"),
    AAM("Having a colonoscopy"),
    AAN("Sitting on the toilet and regretting the chili from the night before"),
    AAO("Omegle"),
    AAP("A horny elk"),
    AAQ("Movie theaters"),
    AAR("Cheese?"),
    AAS("360 no scope"),
    AAT("Blood"),
    AAU("Cookies"),
    AAV("Mimes"),
    AAW("Pokemon being real"),
    AAX("Getting stabbed"),
    AAY("HELP!"),
    AAZ("The idea that killing someone annoying should be ok");




    private final String solutionText;

    //Constructor for the solutiontexts
    private SolutionText(String solutionText){
        this.solutionText = solutionText;
    }

    //A method to acces the String for of the list and not the label
    public String printSolutionText(){
        return solutionText;
    }

}
