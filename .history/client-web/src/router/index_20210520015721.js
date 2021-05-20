import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'list',
    component: () => import('../components/ClientList')
  },
  {
    path: '/new',
    name: 'new',
    component: () => import('../components/ClientCreate')
  },
  {
    path: '/edit/:id',
    name: 'edit',
    component: () => import('../components/ClientEdit')
  },
  {
    path: '/export',
    name: 'export',
    component: () => import('../components/ClientExport')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
