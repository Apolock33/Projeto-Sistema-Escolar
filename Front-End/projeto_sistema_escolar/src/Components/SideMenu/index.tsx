import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import IconButton from '@mui/material/IconButton';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import { Icon } from '@ailibs/feather-react-ts';
import { MenuItemsList } from './listaItensMenu';

const drawerWidth = 240;

interface AppBarProps extends MuiAppBarProps {
    open?: boolean;
}

const AppBar = styled(MuiAppBar, {
    shouldForwardProp: (prop) => prop !== 'open',
})<AppBarProps>(({ theme, open }) => ({
    transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    }),
    ...(open && {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: `${drawerWidth}px`,
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
    }),
}));

const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
}));

export default function SideMenu() {
    const [open, setOpen] = React.useState(true);

    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    return (
        <Box sx={{ display: 'flex' }}>
            <AppBar position="fixed" color='transparent' open={open} style={{ boxShadow: 'none' }}>
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerOpen}
                        edge="start"
                        sx={{ mr: 2, ...(open && { display: 'none' }),  marginTop: '1rem', marginLeft: '0.5rem' }}
                    >
                        <Icon name='menu' />
                    </IconButton>
                </Toolbar>
            </AppBar>
            <Drawer
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    '& .MuiDrawer-paper': {
                        width: drawerWidth,
                        height: ()=> (window.screen.height <= 725 ) ? '38rem' : '43rem',
                        boxSizing: 'border-box',
                        backgroundColor: '#F9F9F9',
                        borderRadius: '2rem',
                        margin: '1rem',
                        border: 'none',
                        fontFamily: 'Roboto, sans-serif'
                    },
                }}
                variant="persistent"
                anchor="left"
                open={open}
            >
                <DrawerHeader>
                    <IconButton onClick={handleDrawerClose}>
                        <Icon name='chevron-left' />
                    </IconButton>
                </DrawerHeader>
                <List>
                    {(MenuItemsList).map((MenuItemsList: any, index: number) => (
                        <ListItem key={index} disablePadding onClick={() => window.location.href = MenuItemsList.link}>
                            <ListItemButton>
                                <ListItemIcon>
                                    <Icon name={MenuItemsList.icon} />
                                </ListItemIcon>
                                <ListItemText primary={MenuItemsList.label} />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </List>
            </Drawer>
        </Box >
    );
}