﻿namespace CharacterHiring.domain.NameGenerator.NameTypes;

public class BaseName
{
    protected NameData _nameData;

    public BaseName(NameData nameData)
    {
        _nameData = nameData;
    }

    protected BaseName()
    {
        throw new NotImplementedException();
    }
}