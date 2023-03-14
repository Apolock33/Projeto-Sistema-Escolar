interface menuItems {
    id?: number;
    label?: string;
    icon?: string;
    link?: string;
    subItems?: any;
    isHeader?: boolean
}

const MenuItemsList: Array<menuItems> = [
    {
        id: 1,
        label: 'Home',
        icon: 'home',
        link: '/'
    },
    {
        id: 2,
        label: 'Instituições',
        icon: 'layers',
        link: '/instituicoes'
    },
    {
        id: 3,
        label: 'Turmas',
        icon: 'edit-2',
        link: '/turmas'
    },
    {
        id: 4,
        label: 'Materias',
        icon: 'book',
        link: '/materias'
    },
    {
        id: 2,
        label: 'Alunos',
        icon: 'user',
        link: '/alunos'
    },
]

export { MenuItemsList };