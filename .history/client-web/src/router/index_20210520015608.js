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
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
