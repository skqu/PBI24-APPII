class Factory
{
    
    static  Factory()
    {

    }

    public iProduct GetProduct(string type)
    {
        switch(type)
        {
            case "shirt":
                return new Shirt();
            case "hat": 
                return new Hat();
        }
        return null;
    }
}