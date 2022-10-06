namespace regex.cSharpRegex
{
    class cSharpRegex
    {
        public void rex()
        {
            //.......................................
            //TODO:1 veri FTR ile baslasin devaminda en az 1 karakter olsun
            string desen = @"FTR.";

            //TODO:girilen verinin ilk karakteri F olsun
            desen = @"^F.";

            //TODO:girilen verinin belli bir kelime ile baslamasi gerekiyorsa
            desen = @"^(2015).";

            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            //TODO:girilen verinin F le bitmsei
            desen = @".F$";

            //TODO:girilen verinin 2011 ile bitmsei
            desen = @".(2015)$";

            //????????????????????????????????????????
            //TODO:girilen ekr@an veriisnde @ yerinebisi yazilmasin veya @ile yazilsin sasdece
            desen = @"ekr@?n.";
            // ekrn => true, ekr@an => true

            //+++++++++++++++++++++++++++++++++++++++++
            //TODO: ekran yazisinda a en az bir kere yada daha falza yazilsin
            desen = @"ekra+n.";
            // ekran => true, ekraaaaan=> true

            //*****************************************
            //TODO: girilne parametrede a harfinin hic, bir ve birden fazla kullanilmasi
            desen = @"ekra*n";
            //ekrn, ekran, ekraaan => true

            //\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d
            //TODO: veri sadece sayilardan olussun
            desen = @"^\d*$"; // @"^\d+$"

            //\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D\D
            //TODO:girilen veride rakam bulunmasin
            desen = @"^\D*$";

            //\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w
            //TODO: girilen verinin alphanumeric olmasi sarti
            desen = @"^\w*$";

            //\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W\W
            //TODO:girilen veri alphanumeric olmasin
            desen = @"^\W*$";

            //{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}
            //TODO: a karakterin 3 kez tekrarlanmasi gerek
            desen = @"ekra{3}n.";
            // ekran, ekraaaaaan => false; ekraaan => true

            //[][][][][][][][][][][][][][][][][][][][][][][]
            //TODO: girilen veri iceriisnde k karakteri yerine sadece k c ve s kullanilabilsin
            desen = @"ek[kcs]ran.";
            // ekran, ecran, esran => true

            string _2 = "abc";
            string _3 = "def";
            string _4 = "ghi";
            string _5 = "jkl";
            string _6 = "mno";
            string _7 = "pqrs";
            string _8 = "tuv";
            string _9 = "wxyz";

            //TODO:for "sapec" type 72732
            string inputNum = "72732";
            // 7=>pqrS 2=>Abc 7=>PqrS 3=>dEf 2=>abC
            // regex => @"[pqrs][abc][pqrs][def][abc]";







        }

    }
}